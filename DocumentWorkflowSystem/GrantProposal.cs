namespace DocumentWorkflowSystem
{
    public class GrantProposal : Document
    {
        private User user;

        public GrantProposal(User user)
        {
            this.user = user;
        }

        public override void createBody()
        {
            
        }
    }
}