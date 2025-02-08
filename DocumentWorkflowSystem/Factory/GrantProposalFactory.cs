using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    public class GrantProposalFactory : DocumentFactory
    {
        public override Document createDocument(User user)
        {
            Document docs = new GrantProposal(user);
            docs.createDocument();
            return docs;
        }
    }
}
