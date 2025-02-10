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

        public void reject(User approver)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void pushBack(User approver)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void approve(User approver)
        {
            Console.WriteLine("This document has already been approved.");
        }
    }
}
