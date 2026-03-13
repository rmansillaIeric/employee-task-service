using EmployeeTaskService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskService.Domain.Entities
{
    public class TaskHistory
    {
        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        public DateTime Fecha { get; set; }

        public string MovementType { get; set; }

        public string? Observations { get; set; }

        public Guid? PreviousEmployeeId { get; set; }

        public Guid? NewEmployeeId { get; set; }

        public TaskItemStatus? PreviousStatus { get; set; }

        public TaskItemStatus? NewStatus { get; set; }

        public string ActionUser { get; set; }

        public TaskItem TaskItem { get; set; }
    }
}
