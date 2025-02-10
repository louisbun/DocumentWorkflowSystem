using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    // Concrete Factory class for creating Grant Proposal documents
    internal class GrantProposalFactory : DocumentFactory
    {
        // Overrides the abstract method from DocumentFactory
        // Creates and returns a new GrantProposal document
        public override Document createDocument(User owner, string title)
        {
            return new GrantProposal(owner, title);
        }
    }
}
