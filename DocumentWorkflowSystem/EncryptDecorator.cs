using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{

    internal class EncryptDecorator : DocumentDecorator
    {
        private string encryptionKey;
      

        public EncryptDecorator(Document document, string encryptionKey) : base(document)
        {
            this.encryptionKey = encryptionKey;
        }

        public override void DisplayDocument()
        {
            base.DisplayDocument();
            Console.WriteLine($"[Document is encrypted with the key {encryptionKey}]");
        }
    }
}
