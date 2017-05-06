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
        private readonly IDictionary<string, IClassificationType> _classificationTypes;

        internal AbmesClassifier(IClassificationTypeRegistryService registry)
        {
            _classificationTypes = new Dictionary<string, IClassificationType>
            {
                [FormatConstants.Namespace] = registry.GetClassificationType(FormatConstants.Namespace),
                [FormatConstants.Local] = registry.GetClassificationType(FormatConstants.Local),
                [FormatConstants.Parameter] = registry.GetClassificationType(FormatConstants.Parameter),
                [FormatConstants.Field] = registry.GetClassificationType(FormatConstants.Field),
                [FormatConstants.Property] = registry.GetClassificationType(FormatConstants.Property),
                [FormatConstants.Event] = registry.GetClassificationType(FormatConstants.Event),
                [FormatConstants.Method] = registry.GetClassificationType(FormatConstants.Method),
                [FormatConstants.Brace] = registry.GetClassificationType(FormatConstants.Brace),
                [FormatConstants.Bracket] = registry.GetClassificationType(FormatConstants.Bracket),
                [FormatConstants.Parenthesis] = registry.GetClassificationType(FormatConstants.Parenthesis),
                [FormatConstants.Colon] = registry.GetClassificationType(FormatConstants.Colon),
                [FormatConstants.Semicolon] = registry.GetClassificationType(FormatConstants.Semicolon),
                [FormatConstants.Comma] = registry.GetClassificationType(FormatConstants.Comma),
                [FormatConstants.AngleBracket] = registry.GetClassificationType(FormatConstants.AngleBracket)
            };
        }

        #pragma warning disable 67
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        #pragma warning restore 67

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var snapshotContext = SnapshotContext.GetContext(span.Snapshot);

            var result = new List<ClassificationSpan>();

            var identifiers = snapshotContext.GetDefaultClassifiedSpans(span).Where(x => x.ClassificationType == ClassificationTypeNames.Identifier);

            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Namespace], SymbolKind.Namespace));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Local], SymbolKind.Local));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Parameter], SymbolKind.Parameter));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Field], SymbolKind.Field));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Property], SymbolKind.Property));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Event], SymbolKind.Event));
            result.AddRange(snapshotContext.ClassifySymbols(identifiers, _classificationTypes[FormatConstants.Method], SymbolKind.Method));

            var punctuation = snapshotContext.GetDefaultClassifiedSpans(span).Where(x => x.ClassificationType == ClassificationTypeNames.Punctuation);

            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Brace], SyntaxKind.OpenBraceToken, SyntaxKind.CloseBraceToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Bracket], SyntaxKind.OpenBracketToken, SyntaxKind.CloseBracketToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Parenthesis], SyntaxKind.OpenParenToken, SyntaxKind.CloseParenToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Colon], SyntaxKind.ColonToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Semicolon], SyntaxKind.SemicolonToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.Comma], SyntaxKind.CommaToken));
            result.AddRange(snapshotContext.ClassifyTokens(punctuation, _classificationTypes[FormatConstants.AngleBracket], SyntaxKind.LessThanToken, SyntaxKind.GreaterThanToken));

            return result;
        }
    }
}
