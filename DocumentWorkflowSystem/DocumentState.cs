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
        void reject(User approver, string? comment);
        void pushBack(User approver, string? comment);
        void approve(User approver);

        void editDocument();

        void addCollaborator();
    }
}
