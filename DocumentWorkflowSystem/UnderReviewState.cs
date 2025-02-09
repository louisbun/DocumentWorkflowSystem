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

        public void submit(User approver)
        {
            Console.WriteLine("This document is already under review.");
        }

        public void reject()
        {
            // unassign the approver 
            myDocument.unassignApprover();

            //unlock Document so that it can be edited
            myDocument.unlockDocument();

            // add reason
            string? comment = myDocument.addRejectedReason();

            // change state to RejectedState
            Console.WriteLine($"Rejecting document [{myDocument.Title}] - Reason: " +  comment);
            myDocument.setState(myDocument.RejectedState);

            // notify all obersvers that document is rejected
            myDocument.notifyObserver("reject");
        }

        public void pushBack()
        {
            // add comment
            string? comment = myDocument.addPushBackReason();

            // unlockDocument so that it can be edited
            myDocument.unlockDocument();

            // change state back to DraftState
            Console.WriteLine($"Pushing document [{myDocument.Title}] back" + " - Reason: " + comment);
            myDocument.setState(myDocument.DraftState);

            // notify all oberservs that document is pushed back
            myDocument.notifyObserver("push back");
        }

        public void approve()
        {
            // change state to ApprovedState
            Console.WriteLine($"Approving document [{myDocument.Title}]");
            myDocument.setState(myDocument.ApprovedState);

            // notify all observers that document is approved
            myDocument.notifyObserver("approve");

        }
    }
}
