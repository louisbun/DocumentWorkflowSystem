using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class User : Observer
    {
        private string name;
        private List<Subject> documents;

        public string Name { get { return name; } set { name = value; } }
        public List<Subject> Document { get { return documents;} }

        public User(string name)
        {
            this.name = name;
            documents = new List<Subject>();
        }

        public void createDocument()
        {
            Console.Write("Enter document title");
            string title = Console.ReadLine();

            Console.Write("Enter document header");
            string header = Console.ReadLine();

            Console.Write("Enter document content");
            string content = Console.ReadLine();

            Console.Write("Enter document footer");
            string footer = Console.ReadLine();

            Document doc = new Document(this, title, header, content, footer);
            documents.Add(doc);
        }

        public void listDocument()
        {
            foreach(Subject subject in documents)
            {
                Console.WriteLine(((Document)subject).Title);
            }
        }
        public void addDocument(Subject doc)
        {
            if (!documents.Contains(doc))
            {
                documents.Add(doc);
            }
        }
        public void removeDocument(Subject doc)
        {
            if (((Document)doc).Owner != this)
            {
                documents.Remove(doc);
            }
        }
        public void update(Subject doc, Observer o, string action)
        {
            if(action == "add")
            {
                Console.WriteLine(Name + " has been notified: " + ((User)o).Name + " ADDED as a collaborator");

            }
            else if(action == "remove")
            {
                Console.WriteLine(Name + " has been notified: " + ((User)o).Name + " REMOVED as a collaborator");
            }
        }
    }
}
