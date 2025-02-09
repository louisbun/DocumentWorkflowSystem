using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal class PDFConvert : ConvertBehaviour
    {
        public void convert(Document document)
        {
            Console.WriteLine($"Converting '{document.Title}' to PDF format...");
            
        }
    }

}
