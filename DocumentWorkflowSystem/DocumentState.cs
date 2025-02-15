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
        void reject(User users, string? comment);
        void pushBack(User users, string? comment);
        void approve(User users);

        void editDocument();

        void addCollaborator(User collaborator);
    }
}
