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

        public TechicalReport(User owner, string title, string content) : base(owner, title, content)
        {
            Header = "Technical Report";
            Footer = "Footer";
        }

        
    }
}
