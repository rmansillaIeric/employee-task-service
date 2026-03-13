using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskService.Domain.Enum
{
    public enum TaskItemStatus
    {
        Pending = 1,
        Assigned = 2,
        InProgress = 3,
        Blocked = 4,
        Completed = 5,
        Cancelled = 6
    }
}
