using MediatR;

namespace EmployeeTaskService.Application.Queries.Employees.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDetailDto?>
    {
        public Guid Id { get; set; }

        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}