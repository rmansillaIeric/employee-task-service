using EmployeeTaskService.Domain.Entities;
using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Commands.Teams.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var exists = await _teamRepository.ExistsByNameAsync(request.Name, cancellationToken);

            if (exists)
                throw new InvalidOperationException("Ya existe un equipo con ese nombre.");

            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = request.Name.Trim(),
                Description = request.Description?.Trim(),
                Active = true
            };

            await _teamRepository.AddAsync(team, cancellationToken);
            await _teamRepository.SaveChangesAsync(cancellationToken);

            return team.Id;
        }
    }
}