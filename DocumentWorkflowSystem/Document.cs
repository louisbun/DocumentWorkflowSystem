using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DocumentWorkflowSystem.ObserverDesignPattern;
using static System.Collections.Specialized.BitVector32;

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
        private bool edited;
        // references to DocumentState (State)
        private DocumentState draftState;
        private DocumentState underReviewState;
        private DocumentState rejectedState;
        private DocumentState approvedState;
        private DocumentState state;


        // yunze stuff (strategy)
        private BaseConverter converter;

        public User Owner { get { return owner; } }
        public string? Title { get { return title; } }
        public string? Content { get { return content; }set { content = value; } }
        public string? Header { get { return header; } set { header = value; } }
        public string? Footer { get { return footer; } set { footer = value; } }
        public User? Approver { get { return approver; } set { approver = value; } }

        // For conversion
        public void SetConverter(BaseConverter newConverter)
        {
            converter = newConverter;
        }

        public BaseConverter getConverter()
        {
            return this.converter;
        }

        public void PerformConvert()
        {
            if (converter != null)
            {
                converter.convert(this);
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
        public bool Edited { get { return edited; } set { edited = value; } }

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
            edited = false;
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
            notifyObserver(o,"add");
        }

        public void removeObserver(Observer o)
        {
            observers.Remove(o);
            notifyObserver(o, "remove");
        }

        public void notifyObserver(Observer o, string action)
        {
            if (action == "add" || action == "remove")
            {
                o.update(this, action, false);
            }
            else
            {
                foreach (Observer observer in observers)
                {
                    if(observer == this.Approver)
                    {
                        continue;
                    }
                    observer.update(this, action, true);
                }
            }
        }

        // State related methods
        public void submit(User approver)
        {
            state.submit(approver);
        }

        public void pushBack(User approver)
        {
            state.pushBack(approver);
        }

        public void reject(User approver)
        {
            state.reject(approver);
        }
        public void approve(User approver)
        {
            state.approve(approver);
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

        public void unassignApprover()
        {
            approver = null;
        }

        public string? addPushBackReason()
        {
            string? comment;
            Console.WriteLine("Enter the reason for pushing back: ");
            comment = Console.ReadLine();
            return comment;
        }

        public string? addRejectedReason()
        {
            string? comment;
            Console.WriteLine("Enter the reason for rejecting: ");
            comment = Console.ReadLine();
            return comment;
        }
    }
}
