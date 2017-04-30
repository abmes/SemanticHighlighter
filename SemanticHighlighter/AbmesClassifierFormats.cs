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
}
