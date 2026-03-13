using EmployeeTaskService.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskService.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskItemStatus Status { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public Guid? AssignedEmployeeId { get; set; }
        public Employee? AssignedEmployee { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
