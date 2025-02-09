using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentWorkflowSystem;

namespace DocumentWorkflowSystem
{
    internal class TechicalReport : Document
    {

        public TechicalReport(User owner, string title) : base(owner, title)
        {
            Header = "Technical Report";
            Footer = "Footer";
        }

        
    }
}
