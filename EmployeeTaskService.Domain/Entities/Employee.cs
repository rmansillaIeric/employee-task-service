using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskService.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Legajo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Active { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }
    }
}
