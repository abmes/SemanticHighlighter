using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SemanticHighlighter
{
    internal static class AbmesClassificationDefinitions
    {
        #pragma warning disable 169

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Brace)]
        private static ClassificationTypeDefinition _braceTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Bracket)]
        private static ClassificationTypeDefinition _bracketTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Parenthesis)]
        private static ClassificationTypeDefinition _parenthesisTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Namespace)]
        private static ClassificationTypeDefinition _namespaceTypeDefinition;

        #pragma warning restore 169
    }
}
