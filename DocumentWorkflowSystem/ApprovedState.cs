using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class ApprovedState : DocumentState
    {
        private Document myDocument;
        public ApprovedState(Document document)
        {
            myDocument = document;
        }

        public void submit(User approver)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void reject()
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void pushBack()
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void approve()
        {
            Console.WriteLine("This document has already been approved.");
        }
    }
}
