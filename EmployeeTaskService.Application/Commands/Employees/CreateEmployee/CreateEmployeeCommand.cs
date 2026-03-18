using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Legajo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Guid TeamId { get; set; }
    }
}