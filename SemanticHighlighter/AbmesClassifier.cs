using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace SemanticHighlighter
{
    internal class AbmesClassifier : IClassifier
    {
        private readonly IClassificationType _braceClassificationType;
        private readonly IClassificationType _bracketClassificationType;
        private readonly IClassificationType _parenClassificationType;
        private readonly IClassificationType _namespaceClassificationType;

        internal AbmesClassifier(IClassificationTypeRegistryService registry)
        {
            _braceClassificationType = registry.GetClassificationType(FormatConstants.Brace);
            _bracketClassificationType = registry.GetClassificationType(FormatConstants.Bracket);
            _parenClassificationType = registry.GetClassificationType(FormatConstants.Parenthesis);
            _namespaceClassificationType = registry.GetClassificationType(FormatConstants.Namespace);
        }

        #pragma warning disable 67
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        #pragma warning restore 67

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var snapshotContext = SnapshotContext.GetContext(span.Snapshot);

            var result = new List<ClassificationSpan>();
            result.AddRange(snapshotContext.ClassifyTokens(span, _braceClassificationType, ClassificationTypeNames.Punctuation, SyntaxKind.OpenBraceToken, SyntaxKind.CloseBraceToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _bracketClassificationType, ClassificationTypeNames.Punctuation, SyntaxKind.OpenBracketToken, SyntaxKind.CloseBracketToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _parenClassificationType, ClassificationTypeNames.Punctuation, SyntaxKind.OpenParenToken, SyntaxKind.CloseParenToken));
            result.AddRange(snapshotContext.ClassifySymbols(span, _namespaceClassificationType, ClassificationTypeNames.Identifier, SymbolKind.Namespace));
            return result;
        }
    }
}
