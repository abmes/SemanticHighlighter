using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace SemanticHighlighter
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp")]
    internal class AbmesClassifierProvider : IClassifierProvider
    {
        #pragma warning disable 649
        [Import]
        private IClassificationTypeRegistryService _classificationRegistry;
        #pragma warning restore 649

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return buffer.Properties.GetOrCreateSingletonProperty(creator: () => new AbmesClassifier(_classificationRegistry));
        }
    }
}
