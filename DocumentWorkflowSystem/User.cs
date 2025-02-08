using DocumentWorkflowSystem.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    public class User
    {
        private int userID;
        private string name;

        public int UserID 
        { get { return userID; } 
          set { userID = value; } 
        }

        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }

        private List<Document> documentList = new List<Document>();

        public List<Document> DocumentList
        { 
            get { return documentList; } 
            set {  documentList = value; }
        }

        public User(string name, int id)
        {
            this.name = name;
            this.userID = id;
        }

        public Document createDocument(DocumentFactory docFactory)
        {
            Document doc = docFactory.createDocument(this);
            return doc;
        }

        public void addDocument(Document docs)
        {
            documentList.Add(docs);
        }

        public void removeDocument(Document docs)
        {
            documentList.Remove(docs);
        }

    }
}
