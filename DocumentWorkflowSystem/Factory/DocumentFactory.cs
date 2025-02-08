using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    internal abstract class DocumentFactory
    {
        public abstract Document createDocument(User user);
    }
}
