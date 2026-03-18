namespace EmployeeTaskService.Application.Queries.Employees.GetEmployees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string Legajo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid TeamId { get; set; }

        public string TeamName { get; set; }

        public bool Active { get; set; }
    }
}