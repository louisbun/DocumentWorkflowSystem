using DocumentWorkflowSystem.Factory;
using DocumentWorkflowSystem.ObserverDesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DocumentWorkflowSystem
{
    internal class User : Observer
    {
        private string name;
        private List<Document> documents;

        public string Name { get { return name; } set { name = value; } }
        public List<Document> Document { get { return documents;} }

        public User(string name)

        {
            this.name = name;
            documents = new List<Document>();
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
            foreach(Document subject in documents)
            {
                if(subject.Owner == this)
                {
                    Console.WriteLine(subject.Title + "(Owner)");
                }
                else if(subject.Approver == this){
                    Console.WriteLine(subject.Title + "(Approver)");
                }
                else
                {
                    Console.WriteLine(subject.Title + "(Collaborator)");
                }
            }
        }
        public void addDocument(Document doc)
        {
            if (!documents.Contains(doc))
            {
                documents.Add(doc);
            }
        }
        public void removeDocument(Document doc)
        {
            if (doc.Owner != this)
            {
                documents.Remove(doc);
            }
        }
        public void update(Document doc, Observer o)
        {
            documents.Add((Document)doc);
            Console.WriteLine(Name + " has been notified: " + Name + " ADDED as a collaborator to "+ doc.Title);
        }
        public void update(Document doc, string action)
        {
            if (action == "submit")
            {
                Console.WriteLine(Name + " has been notified: " + doc.Title + " has been submitted for review");
            }
            else if (action == "push back")
            {
                Console.WriteLine(Name + " has been notified: " + doc.Title + " has been pushed back");
            }
            else if (action == "approve")
            {
                Console.WriteLine(Name + " has been notified: " + doc.Title + " has been approved");
            }
            else if (action == "reject")
            {
                Console.WriteLine(Name + " has been notified: " + doc.Title + " has been rejected");
            }
        }

    }
}
