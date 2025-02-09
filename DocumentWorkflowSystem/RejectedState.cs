using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class RejectedState : DocumentState
    {
        private Document myDocument;
        public RejectedState(Document document)
        {
            this.myDocument = document;
        }

        public void ready(User approver)
        {
            // Guard Condition [only if document has been edited] 
            // change state to UnderReviewState
            // assign approver
            // lock document for editing

            // notify all observers that document is under review
            myDocument.notifyObserver("submit");

        }

        public void reject()
        {
            Console.WriteLine("This document has already been rejected.");
        }

        public void pushBack()
        {
            Console.WriteLine("This document has already been rejected.");
        }

        public void approve()
        {
            Console.WriteLine("This document has already been rejected.");
        }
    }
}
