﻿using System;
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
    internal abstract class Document : Subject
    {
        private List<Observer> observers;
        private User owner;
        private User? approver;

        private string title;

        private string? content;
        private string? header;
        private string? footer;


        // references to DocumentState (State)
        private DocumentState draftState;
        private DocumentState underReviewState;
        private DocumentState rejectedState;
        private DocumentState approvedState;
        private DocumentState state;


        // yunze stuff (strategy)
        private BaseConverter? converter;

        public User Owner { get { return owner; } }
        public string? Title { get { return title; } }
        public string? Content { get { return content; }set { content = value; } }
        public string? Header { get { return header; } set { header = value; } }
        public string? Footer { get { return footer; } set { footer = value; } }
        public User? Approver { get { return approver; } set { approver = value; } }
        public List<Observer> Observers { get { return observers; } }

        // For conversion
        public void SetConverter(BaseConverter newConverter)
        {
            converter = newConverter;
        }

        public BaseConverter? getConverter()
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

        public void pushBack(User users, string? comment)
        {
            state.pushBack(users, comment);
        }

        public void reject(User users, string? comment)
        {
            state.reject(users, comment);
        }
        public void approve(User users)
        {
            state.approve(users);
        }
        public void editDocument()
        {
            state.editDocument();
        }
        public void addCollaborator(User collaborator)
        {
            state.addCollaborator(collaborator);
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


        public virtual void DisplayDocument()
        {
            Console.WriteLine("Document: " + title);
            Console.WriteLine("Header: " + header);
            Console.WriteLine("Body Content: " + content);
            Console.WriteLine("Footer: " + footer);
        }
    }
}
