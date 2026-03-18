using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Queries.Teams.GetTeamById
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamDetailDto?>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamByIdQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamDetailDto?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdWithEmployeesAsync(request.Id, cancellationToken);

            if (team == null)
                return null;

            return new TeamDetailDto
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                Active = team.Active,
                ActiveEmployeesCount = team.Employees.Count(x => x.Active)
            };
        }
    }
}