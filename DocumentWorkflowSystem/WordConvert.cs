using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class WordConvert : BaseConverter
    {
        public override void convertContent()
        {
            Console.WriteLine("Converting document to Word format ...");
        }
    }
}
