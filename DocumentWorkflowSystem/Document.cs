using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class Document : Subject
    {
        private List<Observer> observers;
        private User owner;
        private User? approver;

        private string title;

        private string? content;
        private string? header;
        private string? footer;

        private bool canEdit;
        // references to DocumentState (State)
        private DocumentState draftState;
        private DocumentState underReviewState;
        private DocumentState rejectedState;
        private DocumentState approvedState;
        private DocumentState state;


        // yunze stuff (strategy)
        protected ConvertBehaviour convertBehaviour;

        public User Owner { get { return owner; } }
        public string Title { get { return title; } }
        public string? Content { get { return content; }set { content = value; } }
        public string? Header { get { return header; } set { header = value; } }
        public string? Footer { get { return footer; } set { footer = value; } }
        public User? Approver { get { return approver; } set { approver = value; } }

        // For conversion
        public void SetConvertBehaviour(ConvertBehaviour behaviour)
        {
            this.convertBehaviour = behaviour;
        }
        public ConvertBehaviour GetConvertBehaviour()
        {
            return this.convertBehaviour;
        }

        public void PerformConvert()
        {
            if (convertBehaviour != null)
            {
                convertBehaviour.convert();
            }
            else
            {
                Console.WriteLine("No conversion behaviour set.");
            }
        }

        // getter and setter for state attributes
        public DocumentState DraftState { get { return draftState; } set { draftState = value; } }
        public DocumentState UnderReviewState { get { return underReviewState; } set { underReviewState = value; } }
        public DocumentState RejectedState
        {
            get { return rejectedState; } set { rejectedState = value; }
        }
        public DocumentState ApprovedState
        {
            get { return approvedState; } set { approvedState = value; }
        }
        public DocumentState State
        {
            get { return state; }
        }
        public void setState(DocumentState state)
        {
            this.state = state;
        }

        public bool CanEdit { get { return canEdit; } set { canEdit = value; } }


        // constructor
        public Document(User owner, string title)
        {
            this.owner = owner;

            this.title = title;

            observers = new List<Observer>();

            observers.Add(owner);

            // creating the DocumentState objects
            draftState = new DraftState(this);
            underReviewState = new UnderReviewState(this);
            rejectedState = new RejectedState(this);
            approvedState = new ApprovedState(this);
            state = draftState;

            canEdit = true;
        }

        public void registerObserver(Observer o,User u)
        {
            if(observers.Contains(o))
            {
                Console.WriteLine(((User)o).Name + " is already added.");
            }
            else
            {
                if (u.Equals(owner))
                {
                    observers.Add(o);
                    notifyObserver("add",o);
                }
                else
                {
                    Console.WriteLine("Only owner of document can add collaborators");
                }
            }
        }

        public void removeObserver(Observer o)
        {
            if (observers.Contains(o) && o != owner)
            {
                observers.Remove(o);
            }
            else
            {
                Console.WriteLine(((User)o).Name + " is not a collaborator or is the owner of the document");
            }
            
        }
        public void notifyObserver(string action, Observer observe)
        {
            if(action == "add")
            {
                observe.update(this, observe, action);
            }
            else
            {
                foreach (Observer o in observers)
                {
                    o.update(this, observe, action);
                }
            }
        }

        public void ready(User approver)
        {
            state.ready(approver);
        }

        public void lockDocument()
        {
            canEdit = false;
        }

        public void unlockDocument()
        {
            canEdit = true;
        }

        public bool assignApprover(User approver)
        {
            if (this.approver == approver)
            {
                return true;
            }
            else
            {
                foreach(Observer o in observers)
                {
                    if(approver ==  o)
                    {
                        return false;
                    }
                }
                this.approver = approver;
                return true;
            }
        }
    }
}
