using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal abstract class ConvertDecorator : ConvertBehaviour
    {
        protected ConvertBehaviour converter;

        public ConvertDecorator(ConvertBehaviour converter)
        {
            this.converter = converter;
        }

        public virtual void convert(Document document)
        {
            converter.convert(document);  
        }
    }

}
