using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.DeactivateEmployee
{
    public class DeactivateEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeactivateEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}