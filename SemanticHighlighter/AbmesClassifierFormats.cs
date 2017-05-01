using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SemanticHighlighter
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Namespace)]
    [Name(FormatConstants.Namespace)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesNamespaceFormat : ClassificationFormatDefinition
    {
        public AbmesNamespaceFormat()
        {
            DisplayName = "Abmes Namespace";
            ForegroundColor = Color.FromRgb(120, 10, 170);
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Local)]
    [Name(FormatConstants.Local)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesLocalFormat : ClassificationFormatDefinition
    {
        public AbmesLocalFormat()
        {
            DisplayName = "Abmes Local";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Parameter)]
    [Name(FormatConstants.Parameter)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesParameterFormat : ClassificationFormatDefinition
    {
        public AbmesParameterFormat()
        {
            DisplayName = "Abmes Parameter";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Field)]
    [Name(FormatConstants.Field)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesFieldFormat : ClassificationFormatDefinition
    {
        public AbmesFieldFormat()
        {
            DisplayName = "Abmes Field";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Property)]
    [Name(FormatConstants.Property)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesPropertyFormat : ClassificationFormatDefinition
    {
        public AbmesPropertyFormat()
        {
            DisplayName = "Abmes Property";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Event)]
    [Name(FormatConstants.Event)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesEventFormat : ClassificationFormatDefinition
    {
        public AbmesEventFormat()
        {
            DisplayName = "Abmes Event";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Method)]
    [Name(FormatConstants.Method)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesMethodFormat : ClassificationFormatDefinition
    {
        public AbmesMethodFormat()
        {
            DisplayName = "Abmes Method";
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Brace)]
    [Name(FormatConstants.Brace)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesBraceFormat : ClassificationFormatDefinition
    {
        public AbmesBraceFormat()
        {
            DisplayName = "Abmes Brace";
            ForegroundColor = Colors.Blue;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Bracket)]
    [Name(FormatConstants.Bracket)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesBracketFormat : ClassificationFormatDefinition
    {
        public AbmesBracketFormat()
        {
            DisplayName = "Abmes Bracket";
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Parenthesis)]
    [Name(FormatConstants.Parenthesis)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesParenthesisFormat : ClassificationFormatDefinition
    {
        public AbmesParenthesisFormat()
        {
            DisplayName = "Abmes Parenthesis";
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Colon)]
    [Name(FormatConstants.Colon)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesColonFormat : ClassificationFormatDefinition
    {
        public AbmesColonFormat()
        {
            DisplayName = "Abmes Colon";
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Semicolon)]
    [Name(FormatConstants.Semicolon)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesSemicolonFormat : ClassificationFormatDefinition
    {
        public AbmesSemicolonFormat()
        {
            DisplayName = "Abmes Semicolon";
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.Comma)]
    [Name(FormatConstants.Comma)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesCommaFormat : ClassificationFormatDefinition
    {
        public AbmesCommaFormat()
        {
            DisplayName = "Abmes Comma";
            ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = FormatConstants.AngleBracket)]
    [Name(FormatConstants.AngleBracket)]
    [UserVisible(true)]
    [Order(After = Priority.High)]
    internal sealed class AbmesAngleBracketFormat : ClassificationFormatDefinition
    {
        public AbmesAngleBracketFormat()
        {
            DisplayName = "Abmes Angle Bracket";
            ForegroundColor = Colors.Red;
        }
    }
}
