﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal class Document:Subject
    {
        private List<Observer> observers;
        private User owner;
        private User approver;
        //protected ConvertBehavior convertBehavior; (Strategy pattern)
        private string documentID;
        private string title;
        //private DocumentType type;
        private string content;
        private string header;
        private string footer;

        // references to DocumentState (State)
        private DocumentState draftState;
        private DocumentState underReviewState;
        private DocumentState rejectedState;
        private DocumentState approvedState;
        private DocumentState state;

        protected ConvertBehaviour convertBehaviour;

        public User Owner { get { return owner; } }
        public string Title { get { return title; } }
        public string Content { get { return content; }set { content = value; } }
        public string Header { get { return header; } }
        public string Footer { get { return footer; } }

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


        // constructor
        public Document(User owner, string title, string header, string content, string footer)
        {
            this.owner = owner;
            this.header = header;
            this.title = title;
            this.content = content;
            this.footer = footer;
            observers = new List<Observer>();

            observers.Add(owner);

            // creating the DocumentState objects
            draftState = new DraftState(this);
            underReviewState = new UnderReviewState(this);
            rejectedState = new RejectedState(this);
            approvedState = new ApprovedState(this);
            state = draftState;
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
    }
}
