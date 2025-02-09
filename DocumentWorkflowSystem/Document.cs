﻿using System;
using System.Collections.Generic;
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

        private string content;
        private string? header;
        private string? footer;

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
        public string Content { get { return content; }set { content = value; } }
        public string? Header { get { return header; } set { header = value; } }
        public string? Footer { get { return footer; } set { footer = value; } }
        public User Approver { get { return approver; } set { approver = value; } }

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
        }

        public void registerObserver(Observer o)
        {
            if(observers.Contains(o))
            {
                Console.WriteLine(((User)o).Name + " is already added.");
            }
            else
            {
                observers.Add(o);
                notifyObserver(o);
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
        public void notifyObserver(Observer observe)
        {
            observe.update(this, observe);
        }

        public void notifyObserver(string action)
        {
            foreach (Observer o in observers)
            {
                o.update(this,action);
            }
        }

        public void assignApprover(User approver)
        {
            
        }
    }
}
