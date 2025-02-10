namespace DocumentWorkflowSystem
{
    // Extends base Document class
    internal class GrantProposal : Document
    {
        // Contains attributes of header and footer
        public GrantProposal(User owner, string title) : base(owner, title)
        {
            Header = "Grant Proposal";
            Footer = "Standard Footer";
        }      
    }
}