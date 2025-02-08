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

        public User Owner { get { return owner; } }
        public string Title { get { return title; } }

        public Document(User owner, string title, string header, string content, string footer)
        {
            this.owner = owner;
            this.header = header;
            this.title = title;
            this.content = content;
            this.footer = footer;
            observers = new List<Observer>();
        }

        public void registerObserver(Observer o)
        {
            if(observers.Contains(o))
            {
                Console.WriteLine(((User)o).Name + " is already added.");
            }
            else
            {
                if (o.Equals(owner))
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
            foreach (Observer o in observers)
            {
                o.update(this, observe,action);
            }
        }
    }
}
