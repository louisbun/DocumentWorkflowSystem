using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWorkflowSystem
{
    internal interface DocumentState
    {
        void submit(User approver);
        void reject(User approver);
        void pushBack(User approver);
        void approve(User approver);

    }
}
