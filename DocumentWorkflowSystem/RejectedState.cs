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

        public void submit(User approver)
        {
            //// Guard Condition [only if document has been edited] 
            //if (myDocument.Edited)
            //{
            //    if (myDocument.assignApprover(approver))
            //    {
            //        // lock the document to not allow editing
            //        myDocument.lockDocument();

            //        // change the state to UnderReviewState
            //        Console.WriteLine("Sending this document to be reviewed...");
            //        myDocument.setState(myDocument.UnderReviewState);

            //        // notify all the observers that document is under review
            //        myDocument.notifyObserver(approver,"submit");
            //        approver.addDocument(myDocument);

            //    }
            //    else
            //    {
            //        Console.WriteLine("Please assign an approver who is not a " +
            //            "collaborator of this document.");
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Document has already been rejected. " +
            //        "it has to be edited first before re-submitting.");
            //    Console.WriteLine();
            //}

            Console.WriteLine("Unable to submit for review while document is rejected. " +
                "Please edit it first.");
        }

        public void reject(User users, string? comment)
        {
            Console.WriteLine("This document has already been rejected.");
        }

        public void pushBack(User users, string? comment)
        {
            Console.WriteLine("This document can't be push back - it has already been rejected.");
        }

        public void approve(User users)
        {
            Console.WriteLine("This document can't be approved - it has already been rejected.");
        }

        public void editDocument()
        {
            Console.WriteLine("Add text to document");
            string? text = Console.ReadLine();
            myDocument.Content += "\n" + text;

            // change state to DraftState after document has been edited
            myDocument.setState(myDocument.DraftState);
        }

        public void addCollaborator(User collaborator)
        {
            Console.WriteLine("Unable to add collaborator while document is rejected. " +
                "Please edit it first.");
        }
    }
}
