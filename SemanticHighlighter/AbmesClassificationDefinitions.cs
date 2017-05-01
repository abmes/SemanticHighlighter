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
        [Name(FormatConstants.Namespace)]
        private static ClassificationTypeDefinition _namespaceTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Local)]
        private static ClassificationTypeDefinition _localTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Parameter)]
        private static ClassificationTypeDefinition _parameterTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Field)]
        private static ClassificationTypeDefinition _fieldTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Property)]
        private static ClassificationTypeDefinition _propertyTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Event)]
        private static ClassificationTypeDefinition _eventTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Method)]
        private static ClassificationTypeDefinition _methodTypeDefinition;

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
        [Name(FormatConstants.Colon)]
        private static ClassificationTypeDefinition _colonTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Semicolon)]
        private static ClassificationTypeDefinition _semicolonTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.Comma)]
        private static ClassificationTypeDefinition _commaTypeDefinition;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name(FormatConstants.AngleBracket)]
        private static ClassificationTypeDefinition _angleBracketTypeDefinition;

        #pragma warning restore 169
    }
}
