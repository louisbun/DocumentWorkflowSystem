using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    // Concrete factory class for creating TechnicalReport documents
    internal class TechnicalReportFactory : DocumentFactory
    {
        // Overrides the abstract method from DocumentFactory
        // Creates and returns a new TechnicalReport document
        public override Document createDocument(User owner, string title)
        {
            return new TechicalReport(owner, title);
        }
    }
}
