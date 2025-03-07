﻿using System;
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
                addCollaborator(approver);
            }
            else
            {
                Console.WriteLine("Please assign an approver who is not a " +
                    "collaborator of this document.");
                Console.WriteLine();
            }

        }

        public void reject(User users, string? comment)
        {
            Console.WriteLine("This document can't be rejected during draft.");
        }

        public void pushBack(User users, string? comment)
        {
            Console.WriteLine("This document cannot be push back during draft.");
        }

        public void approve(User users)
        {
            Console.WriteLine("This document cannot be approved during draft.");
        }

        public void editDocument()
        {
            Console.WriteLine("Add text to document");
            string? text = Console.ReadLine();
            myDocument.Content += "\n" + text;
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
