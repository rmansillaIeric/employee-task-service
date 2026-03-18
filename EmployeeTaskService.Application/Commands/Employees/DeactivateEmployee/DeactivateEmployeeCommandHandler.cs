using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Commands.Employees.DeactivateEmployee
{
    public class DeactivateEmployeeCommandHandler : IRequestHandler<DeactivateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeactivateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeactivateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee == null)
                return false;

            if (!employee.Active)
                return true;

            employee.Active = false;

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            await _employeeRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}