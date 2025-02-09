using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal class WatermarkDecorator : ConvertDecorator
    {
        private string watermarkText;
        public string WaterMarkText { get { return watermarkText; } set { watermarkText = value; } }
        public WatermarkDecorator(ConvertBehaviour converter, string watermark) : base(converter)
        {
            this.watermarkText = watermark;
        }

        public override void convert(Document document)
        {
            
            base.convert(document);
            AddWatermark();
        }

        public void AddWatermark()
        {
            Console.WriteLine($"Adding watermark: {watermarkText}");
        }
    }

}
