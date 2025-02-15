using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{

    internal class WatermarkDecorator : DocumentDecorator
    {
        private string? watermarkText;
        

        public WatermarkDecorator(Document document, string? watermarkText) : base(document)
        {
            this.watermarkText = watermarkText;
        }

        public override void DisplayDocument()
        {
            base.DisplayDocument();
            Console.WriteLine($"[Watermark: {watermarkText}]");
        }
    }

}
