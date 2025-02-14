using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{

    internal abstract class DocumentDecorator : Document
    {
        
        protected Document document; 

        public DocumentDecorator(Document document) : base(document.Owner, document.Title)
        {
            this.document = document;
        }

        public override void DisplayDocument()
        {
            document.DisplayDocument(); 
        }
    }

}
