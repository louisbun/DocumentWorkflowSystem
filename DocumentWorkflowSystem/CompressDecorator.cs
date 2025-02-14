using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{

    internal class CompressDecorator : DocumentDecorator
    {
        
        public CompressDecorator(Document document) : base(document) { }

        public override void DisplayDocument()
        {
            base.DisplayDocument();
            Console.WriteLine("[Document is compressed]");
        }
    }

}
