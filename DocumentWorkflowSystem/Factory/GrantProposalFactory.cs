using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    internal class GrantProposalFactory : DocumentFactory
    {
        public GrantProposalFactory() {

        }
        public override Document createDocument()
        {
            return new GrantProposal();
        }
    }
}
