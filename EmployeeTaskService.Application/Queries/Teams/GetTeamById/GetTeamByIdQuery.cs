using MediatR;

namespace EmployeeTaskService.Application.Queries.Teams.GetTeamById
{
    public class GetTeamByIdQuery : IRequest<TeamDetailDto?>
    {
        public Guid Id { get; set; }

        public GetTeamByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}