using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Queries.Teams.GetTeams
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, List<TeamDto>>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamsQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<TeamDto>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllAsync(cancellationToken);

            return teams.Select(x => new TeamDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Active = x.Active
            }).ToList();
        }
    }
}