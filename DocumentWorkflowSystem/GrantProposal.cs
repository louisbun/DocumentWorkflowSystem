namespace DocumentWorkflowSystem
{
    internal class GrantProposal : Document
    {


        public GrantProposal(User owner, string title, string content) : base(owner, title, content)
        {
            Header = "Grant Proposal";
            Footer = "Standard Footer";
        }

        
    }
}