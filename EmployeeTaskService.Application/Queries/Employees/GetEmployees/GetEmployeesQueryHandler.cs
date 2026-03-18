using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Queries.Employees.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetFilteredAsync(
                request.TeamId,
                request.Active,
                request.Search,
                cancellationToken);

            return employees.Select(x => new EmployeeDto
            {
                Id = x.Id,
                Legajo = x.Legajo,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                TeamId = x.TeamId,
                TeamName = x.Team.Name,
                Active = x.Active
            }).ToList();
        }
    }
}