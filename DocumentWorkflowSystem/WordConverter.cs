using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class WordConverter : BaseConverter
    {
        public WordConverter(ConvertBehaviour behaviour) : base(behaviour) { }


        public override void applyFormatting(Document document)
        {
            Console.WriteLine($"Applying Word formatting (styles, headers) for '{document.Title}'...");
        }

        public override void generateFileName(Document document)
        {
            Console.WriteLine($"Generating Word file name: {document.Title}.docx");
        }
    }
}
