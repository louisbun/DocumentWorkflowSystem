using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal abstract class BaseConverter 
    {
        
        protected ConvertBehaviour convertBehaviour;  // Strategy instance

        public ConvertBehaviour getConvertBehaviour()
        {
            return convertBehaviour;
        }

        public BaseConverter(ConvertBehaviour behaviour)
        {
            convertBehaviour = behaviour;
        }

        public void convert(Document document)  // Template Method
        {
           
            prepareDocument(document);
            applyFormatting(document);
            performConvert(document);  // Calls Strategy dynamically
            generateFileName(document);
            finaliseConvert(document);
        }

        public void performConvert(Document document)
        {
            convertBehaviour.convert(document);
        }
        public abstract void applyFormatting(Document document);
        public abstract void generateFileName(Document document);

        public void prepareDocument(Document document)
        {
            Console.WriteLine($"Preparing '{document.Title}' for conversion...");
        }

        public void finaliseConvert(Document document)
        {
            Console.WriteLine($"Finalizing conversion of '{document.Title}'.");
        }
    }
}
