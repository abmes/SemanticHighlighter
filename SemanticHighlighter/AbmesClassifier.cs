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
                [FormatConstants.Brace] = registry.GetClassificationType(FormatConstants.Brace),
                [FormatConstants.Bracket] = registry.GetClassificationType(FormatConstants.Bracket),
                [FormatConstants.Parenthesis] = registry.GetClassificationType(FormatConstants.Parenthesis),
                [FormatConstants.Colon] = registry.GetClassificationType(FormatConstants.Colon),
                [FormatConstants.Semicolon] = registry.GetClassificationType(FormatConstants.Semicolon),
                [FormatConstants.Comma] = registry.GetClassificationType(FormatConstants.Comma)
            };
        }

        #pragma warning disable 67
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
        #pragma warning restore 67

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var snapshotContext = SnapshotContext.GetContext(span.Snapshot);

            var result = new List<ClassificationSpan>();
            result.AddRange(snapshotContext.ClassifySymbols(span, _classificationTypes[FormatConstants.Namespace], ClassificationTypeNames.Identifier, SymbolKind.Namespace));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Brace], ClassificationTypeNames.Punctuation, SyntaxKind.OpenBraceToken, SyntaxKind.CloseBraceToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Bracket], ClassificationTypeNames.Punctuation, SyntaxKind.OpenBracketToken, SyntaxKind.CloseBracketToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Parenthesis], ClassificationTypeNames.Punctuation, SyntaxKind.OpenParenToken, SyntaxKind.CloseParenToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Colon], ClassificationTypeNames.Punctuation, SyntaxKind.ColonToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Semicolon], ClassificationTypeNames.Punctuation, SyntaxKind.SemicolonToken));
            result.AddRange(snapshotContext.ClassifyTokens(span, _classificationTypes[FormatConstants.Comma], ClassificationTypeNames.Punctuation, SyntaxKind.CommaToken));
            return result;
        }
    }
}
