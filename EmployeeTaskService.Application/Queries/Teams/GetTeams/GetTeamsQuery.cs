using MediatR;

namespace EmployeeTaskService.Application.Queries.Teams.GetTeams
{
    public class GetTeamsQuery : IRequest<List<TeamDto>>
    {
    }
}