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
        public List<Document> Documents { get { return documents;} }

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
                //Adds document to List of document that user is a part of (Owner/Collab)
                documents.Add(doc);
                //Register user as observer of document
                doc.registerObserver(this);

            }
            else
            {
                if(doc.Owner == this)
                {
                    Console.WriteLine($"{doc.Owner.Name} is the OWNER of this document");
                }else if(doc.Approver == this){
                    Console.WriteLine($"{doc.Approver.Name} is the APPROVER of this document");
                }
                else
                {
                    Console.WriteLine($"Already a collaborator this document");
                }
            }
        }
        public void removeDocument(Document doc)
        {
            documents.Remove(doc);
            doc.removeObserver(this);
        }
        public void update(Document doc, string action, bool notifyAll)
        {
            if(notifyAll)
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
            else
            {
                if(action == "add")
                {
                    //documents.Add(doc);
                    if (doc.Approver == this)
                    {
                        Console.WriteLine($"{Name} has been notified: {Name} ADDED as a Approver to {doc.Title}");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} has been notified: {Name} ADDED as a Collaborator to {doc.Title}");
                    }
                }
                else
                {
                    if(doc.Approver == this)
                    {
                        Console.WriteLine($"{Name} has been notified: {Name} left {doc.Title}");
                    }
                }
            }
        }
    }
}
