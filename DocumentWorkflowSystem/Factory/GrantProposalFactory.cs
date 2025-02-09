using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    internal class GrantProposalFactory : DocumentFactory
    {

        public override Document createDocument(User owner, string title)
        {
            return new GrantProposal(owner, title);
        }
    }
}
