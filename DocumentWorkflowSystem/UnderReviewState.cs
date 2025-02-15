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

        public void reject(User users, string? comment)
        {
            // unassign the approver 
            myDocument.unassignApprover();

            // change state to RejectedState
            Console.WriteLine($"Rejecting document [{myDocument.Title}] - Reason: " +  comment);
            myDocument.setState(myDocument.RejectedState);

            // notify all obersvers that document is rejected
            users.removeDocument(myDocument);
            myDocument.notifyObserver(users,"reject");
        }

        public void pushBack(User users, string? comment)
        {

            // change state back to DraftState
            Console.WriteLine($"Pushing document [{myDocument.Title}] back" + " - Reason: " + comment);
            myDocument.setState(myDocument.DraftState);

            // notify all oberservs that document is pushed back
            myDocument.notifyObserver(users, "push back");
        }

        public void approve(User users)
        {
            // change state to ApprovedState
            Console.WriteLine($"Approving document [{myDocument.Title}]...");
            myDocument.setState(myDocument.ApprovedState);

            // notify all observers that document is approved
            myDocument.notifyObserver(users, "approve");

        }

        public void editDocument()
        {
            Console.WriteLine("This document cannot be " +
                        "edited currently - it is under review.");
            Console.WriteLine();
        }

        public void addCollaborator(User collaborator)
        {
            if (!collaborator.Documents.Contains(myDocument))
            {
                //Adds document to List of document that user is a part of (Owner/Collab)
                collaborator.Documents.Add(myDocument);
                //Register user as observer of document
                myDocument.registerObserver(collaborator);

            }
            else
            {
                if (myDocument.Owner == collaborator)
                {
                    Console.WriteLine($"{myDocument.Owner.Name} is the OWNER of this document");
                }
                else if (myDocument.Approver == collaborator)
                {
                    Console.WriteLine($"{myDocument.Approver.Name} is the APPROVER of this document");
                }
                else
                {
                    Console.WriteLine($"Already a collaborator this document");
                }
            }
        }
    }
}
