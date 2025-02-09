using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal class CompressDecorator : ConvertDecorator
    {
        

        public CompressDecorator(ConvertBehaviour converter) : base(converter)
        {
            
        }

        public override void convert(Document document)
        {
            
            base.convert(document);
            CompressDocument();
        }

        public void CompressDocument()
        {
            Console.WriteLine("Compressing document before conversion...");
        }
    }

}
