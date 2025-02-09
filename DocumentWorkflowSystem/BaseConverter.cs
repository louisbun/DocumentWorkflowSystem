using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    public abstract class BaseConverter : ConvertBehaviour
    {
        public void convert()
        {
            prepareDocument();
            convertContent();
            finaliseConvert();
        }
        public void prepareDocument()
        {
            Console.WriteLine("Preparing document for conversion...");
        }
        public abstract void convertContent();
        public void finaliseConvert()
        {
            Console.WriteLine("Finalising document conversion.");
        }
    }
}
