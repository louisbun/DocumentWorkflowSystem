using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class UnderReviewState : DocumentState
    {
        private Document myDocument;
        public UnderReviewState(Document document)
        {
            myDocument = document;
        }

        public void ready()
        {
            Console.WriteLine("This document is already under review.");
        }

        public void reject()
        {
            // unassign the approver 
            // add reason
            // change state to RejectedState

            // notify all obersvers that document is rejected
        }

        public void pushBack()
        {
            // keep approver
            // add comment
            // change state back to DraftState

            // notify all oberservs that document is pushed back
        }

        public void approve()
        {
            // change state to ApprovedState

            // notify all observers that document is approved
        }
    }
}
