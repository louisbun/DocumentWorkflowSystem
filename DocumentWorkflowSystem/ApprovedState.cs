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

        public void reject(User users, string? comment)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void pushBack(User users, string? comment)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void approve(User users)
        {
            Console.WriteLine("This document has already been approved.");
        }

        public void editDocument()
        {
            Console.WriteLine("This document has already been approved and " +
                "can't be edited any further.");
        }

        public void addCollaborator(User collaborator)
        {
            Console.WriteLine("This document has already been approved. " +
                "Unable to add anymore collaborators.");
        }
    }
}
