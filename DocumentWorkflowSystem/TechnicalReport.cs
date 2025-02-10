using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentWorkflowSystem;

namespace DocumentWorkflowSystem
{
    // Extends base Document class
    internal class TechicalReport : Document
    {
        // Contains attributes
        public TechicalReport(User owner, string title) : base(owner, title)
        {
            Header = "Technical Report";
            Footer = "Footer";
        }        
    }
}
