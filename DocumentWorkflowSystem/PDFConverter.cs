using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class PDFConverter : BaseConverter
    {
        public PDFConverter(ConvertBehaviour behaviour) : base(behaviour) { }


        public override void applyFormatting(Document document)
        {
            Console.WriteLine($"Applying PDF formatting for '{document.Title}'...");
        }

        public override void generateFileName(Document document)
        {
            Console.WriteLine($"Generating PDF file name: {document.Title}.pdf");
        }
    }
}
