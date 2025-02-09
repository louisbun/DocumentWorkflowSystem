using DocumentWorkflowSystem.Factory;
using DocumentWorkflowSystem.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
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

        public Document createDocument(string type, string title)
        {
            Document doc;
            if (type == "Grant")
            {
                GrantProposalFactory grantProposalFactory = new GrantProposalFactory();
                doc = grantProposalFactory.createDocument(this, title);
            }
            else
            {
                TechnicalReportFactory technicalReportFactory = new TechnicalReportFactory();
                doc = technicalReportFactory.createDocument(this, title);
            }
            documents.Add(doc);
            return doc;
        }

        public void listDocument()
        {
            foreach(Subject subject in documents)
            {
                if(((Document)subject).Owner == this)
                {
                    Console.WriteLine(((Document)subject).Title + "(Owner)");
                }
                else
                {
                    Console.WriteLine(((Document)subject).Title + "(Collaborator)");
                }
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
                documents.Add((Document)doc);
                Console.WriteLine(Name + " has been notified: " + ((User)o).Name + " ADDED as a collaborator");

            }
            else if(action == "remove")
            {
                documents.Remove((Document)doc);
                Console.WriteLine(Name + " has been notified: " + ((User)o).Name + " REMOVED as a collaborator");
            }
            else if(action == "submit")
            {
                Console.WriteLine(Name + " has been notified: " + ((Document)doc).Title + " has been submitted for review");
            }
            else if (action == "push back")
            {
                Console.WriteLine(Name + " has been notified: " + ((Document)doc).Title + " has been pushed back");
            }
            else if (action == "approve")
            {
                Console.WriteLine(Name + " has been notified: " + ((Document)doc).Title + " has been approved");
            }
            else if (action == "reject")
            {
                Console.WriteLine(Name + " has been notified: " + ((Document)doc).Title + " has been rejected");
            }
        }

    }
}
