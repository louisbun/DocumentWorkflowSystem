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

        public void ready(User approver)
        {
            
            // assign approver if empty
            if (myDocument.assignApprover(approver))
            {
                // lock the document to not allow editing
                myDocument.lockDocument();

                // change the state to UnderReviewState
                Console.WriteLine("Sending this document to be reviewed...");
                myDocument.setState(myDocument.UnderReviewState);

                // notify all the observers that document is under review

            }
            else
            {
                Console.WriteLine("Please assign an approver who is not a " +
                    "collaborator of this document.");
                Console.WriteLine();
            }

        }

        public void reject()
        {
            Console.WriteLine("This document can't be rejected during draft.");
        }

        public void pushBack()
        {
            Console.WriteLine("This document cannot be push back during draft.");
        }

        public void approve()
        {
            Console.WriteLine("This document cannot be approved during draft.");
        }
    }
}
