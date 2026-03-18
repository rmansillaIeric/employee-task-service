using MediatR;

namespace EmployeeTaskService.Application.Queries.Employees.GetEmployees
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
    {
        public Guid? TeamId { get; set; }
        public bool? Active { get; set; }
        public string? Search { get; set; }
    }
}