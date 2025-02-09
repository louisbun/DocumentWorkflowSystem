using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal class WordConvert : ConvertBehaviour
    {
        public void convert(Document document)
        {
            Console.WriteLine($"Converting '{document.Title}' to Word format...");
           
        }
    }

}
