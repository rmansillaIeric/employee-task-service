using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Queries.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDetailDto?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDetailDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdWithTeamAsync(request.Id, cancellationToken);

            if (employee == null)
                return null;

            return new EmployeeDetailDto
            {
                Id = employee.Id,
                Legajo = employee.Legajo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                FechaIngreso = employee.FechaIngreso,
                Active = employee.Active,
                TeamId = employee.TeamId,
                TeamName = employee.Team.Name
            };
        }
    }
}