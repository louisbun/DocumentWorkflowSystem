using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class DraftState : DocumentState
    {
        private Document myDocument;
        public DraftState(Document document)
        {
            myDocument = document;
        }

        public void submit(User approver)
        {
            
            // assign approver if empty [if approver is not a collaborator]
            if (myDocument.assignApprover(approver))
            {

                // change the state to UnderReviewState
                Console.WriteLine("Sending this document to be reviewed...");
                myDocument.setState(myDocument.UnderReviewState);

                // notify all the observers that document is under review
                myDocument.notifyObserver(approver, "submit");
                approver.addDocument(myDocument);
            }
            else
            {
                Console.WriteLine("Please assign an approver who is not a " +
                    "collaborator of this document.");
                Console.WriteLine();
            }

        }

        public void reject(User approver, string? comment)
        {
            Console.WriteLine("This document can't be rejected during draft.");
        }

        public void pushBack(User approver, string? comment)
        {
            Console.WriteLine("This document cannot be push back during draft.");
        }

        public void approve(User approver)
        {
            Console.WriteLine("This document cannot be approved during draft.");
        }

        public void editDocument()
        {
            Console.WriteLine("Add text to document");
            string? text = Console.ReadLine();
            myDocument.Content += "\n" + text;
        }
    }
}
