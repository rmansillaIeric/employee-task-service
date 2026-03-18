using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Legajo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Guid TeamId { get; set; }
        public bool Active { get; set; }
    }
}