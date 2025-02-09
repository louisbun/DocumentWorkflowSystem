using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem.ObserverDesignPattern
{
    interface Observer
    {
        void update(Subject sub, Observer o, string action);
    }
}
