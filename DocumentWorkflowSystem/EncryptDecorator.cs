using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    
    internal class EncryptDecorator : ConvertDecorator
    {
        private string encrypt;
        public string Encrypt { get { return encrypt; } set { encrypt = value; } }

        public EncryptDecorator(ConvertBehaviour converter, string encrypt) : base(converter)
        {
            this.encrypt = encrypt;
        }

        public override void convert(Document document)
        {
            
            base.convert(document);
            EncryptDocument();
        }

        private void EncryptDocument()
        {
            Console.WriteLine($"Encrypting document with key: {encrypt}");
        }
    }
}
