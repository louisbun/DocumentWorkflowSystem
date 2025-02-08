using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentWorkflowSystem;

namespace DocumentWorkflowSystem
{
    public class TechicalReport : Document
    {
        private User user;

        public TechicalReport(User user)
        {
            this.user = user;
        }

        public override void createBody()
        {
            
        }
    }
}
