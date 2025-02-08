using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    public class TechnicalReportFactory : DocumentFactory
    {
        public override Document createDocument(User user)
        {
            Document docs = new TechicalReport(user);
            docs.createDocument();
            return docs;
        }
    }
}
