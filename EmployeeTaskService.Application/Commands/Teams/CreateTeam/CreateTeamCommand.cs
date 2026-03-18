using MediatR;

namespace EmployeeTaskService.Application.Commands.Teams.CreateTeam
{
    public class CreateTeamCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}