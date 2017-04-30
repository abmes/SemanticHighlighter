using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace SemanticHighlighter
{
    internal class SnapshotContext
    {
        private Workspace _workspace;
        private Document _document;
        private SemanticModel _semanticModel;
        private SyntaxNode _syntaxRoot;

        private static IDictionary<ITextSnapshot, SnapshotContext> _cachedContexts = new Dictionary<ITextSnapshot, SnapshotContext>();

        public SnapshotContext(ITextSnapshot snapshot)
        {
            _workspace = snapshot.TextBuffer.GetWorkspace();
            _document = snapshot.GetOpenDocumentInCurrentContextWithChanges();
            if (_document != null)
            {
                _semanticModel = _document.GetSemanticModelAsync().Result;
                _syntaxRoot = _document.GetSyntaxRootAsync().Result;
            }
        }

        private IEnumerable<ClassifiedSpan> GetClassifiedSpans(SnapshotSpan span, string classificationType)
        {
            if (_document == null)
            {
                return Enumerable.Empty<ClassifiedSpan>();
            }

            var textSpan = TextSpan.FromBounds(span.Start, span.End);
            return Classifier.GetClassifiedSpans(_semanticModel, textSpan, _workspace).Where(x => x.ClassificationType == classificationType);
        }

        public IEnumerable<ClassificationSpan> ClassifyTokens(SnapshotSpan span, IClassificationType classificationType, string parentClassificationType, params SyntaxKind[] syntaxKinds)
        {
            var parentClassifiedSpans = GetClassifiedSpans(span, parentClassificationType);
            var matchedTokens = parentClassifiedSpans.Select(x => _syntaxRoot.FindToken(x.TextSpan.Start)).Where(x => syntaxKinds.Any(sk => x.IsKind(sk)));
            return matchedTokens.Select(x => new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(x.Span.Start, x.Span.Length)), classificationType));
        }

        public IEnumerable<ClassificationSpan> ClassifySymbols(SnapshotSpan span, IClassificationType classificationType, string parentClassificationType, params SymbolKind[] symbolKinds)
        {
            var parentClassifiedSpans = GetClassifiedSpans(span, parentClassificationType);
            return parentClassifiedSpans
                .Where(x =>
                {
                    var node = _syntaxRoot.FindNode(x.TextSpan);
                    var symbol = _semanticModel.GetSymbolInfo(node).Symbol ?? _semanticModel.GetDeclaredSymbol(node);
                    return (symbol != null) && symbolKinds.Contains(symbol.Kind);
                })
                .Select(x => new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(x.TextSpan.Start, x.TextSpan.Length)), classificationType));
        }

        public static SnapshotContext GetContext(ITextSnapshot snapshot)
        {
            if (!_cachedContexts.ContainsKey(snapshot))
            {
                _cachedContexts[snapshot] = new SnapshotContext(snapshot);
            }

            return _cachedContexts[snapshot];
        }
    }
}
