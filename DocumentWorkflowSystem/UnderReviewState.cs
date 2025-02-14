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

        public void reject(User approver, string? comment)
        {
            // unassign the approver 
            myDocument.unassignApprover();

            // change state to RejectedState
            Console.WriteLine($"Rejecting document [{myDocument.Title}] - Reason: " +  comment);
            myDocument.setState(myDocument.RejectedState);

            // notify all obersvers that document is rejected
            approver.removeDocument(myDocument);
            myDocument.notifyObserver(approver,"reject");
        }

        public void pushBack(User approver, string? comment)
        {

            // change state back to DraftState
            Console.WriteLine($"Pushing document [{myDocument.Title}] back" + " - Reason: " + comment);
            myDocument.setState(myDocument.DraftState);

            // notify all oberservs that document is pushed back
            myDocument.notifyObserver(approver, "push back");
        }

        public void approve(User approver)
        {
            // change state to ApprovedState
            Console.WriteLine($"Approving document [{myDocument.Title}]...");
            myDocument.setState(myDocument.ApprovedState);

            // notify all observers that document is approved
            myDocument.notifyObserver(approver, "approve");

        }

        public void editDocument()
        {
            Console.WriteLine("This document cannot be " +
                        "edited currently - it is under review.");
            Console.WriteLine();
        }

        public void addCollaborator()
        {

        }
    }
}
