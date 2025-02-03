using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class Document
    {
        //protected ConvertBehavior convertBehavior; (Strategy pattern)
        private string documentID;
        private string title;
        //private DocumentType type; (State Pattern)
        private string content;
        private string header;
        private string footer; 
    }
}
