using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    public class User
    {
        private int userID;
        private string name;

        public int UserID { get { return userID; } 
            set { userID = value; } }

        public string Name { get { return name; } 
            set { name = value; } }

        public User(string name, int id)
        {
            this.name = name;
            this.userID = id;
        }
    }
}
