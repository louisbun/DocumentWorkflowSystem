using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.Factory
{
    // Abstract factory class for creating docuements
    internal abstract class DocumentFactory
    {
        // Abstract method to be implemented by derived classes
        // Return a Document object and take a User object (owner) and a title as parameters
        // Forces all concrete factories to follow the method
        public abstract Document createDocument(User owner, string title);
    }
}
