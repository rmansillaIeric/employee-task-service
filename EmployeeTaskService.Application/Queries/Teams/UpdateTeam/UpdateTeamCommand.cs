using MediatR;

namespace EmployeeTaskService.Application.Commands.Teams.UpdateTeam
{
    public class UpdateTeamCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}