namespace DocumentWorkflowSystem
{
    internal class GrantProposal : Document
    {


        public GrantProposal(User owner, string title) : base(owner, title)
        {
            Header = "Grant Proposal";
            Footer = "Standard Footer";
        }

        
    }
}