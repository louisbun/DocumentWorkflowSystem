using DocumentWorkflowSystem.Factory;
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
            Console.WriteLine("Document Types");
            Console.WriteLine("1. Grant Proposal");
            Console.WriteLine("2. Technical Report");
            int docNo;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Enter document type: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out docNo))
                {
                    // if the integer is either 1 or 2, valid
                    if (docNo == 1 || docNo == 2)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 1 or 2.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Document doc;

                if (docNo == 1)
                {
                    GrantProposalFactory grantProposalFactory = new GrantProposalFactory();
                    doc = createDocument(grantProposalFactory);
                }

                else
                {
                    TechnicalReportFactory technicalReportFactory = new TechnicalReportFactory();
                    doc = createDocument(technicalReportFactory);
                }
                documents.Add(doc);
            }
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

        public Document createDocument(DocumentFactory docFactory)
        {
            Document doc = docFactory.createDocument(this);
            return doc;
        }
    }
}
