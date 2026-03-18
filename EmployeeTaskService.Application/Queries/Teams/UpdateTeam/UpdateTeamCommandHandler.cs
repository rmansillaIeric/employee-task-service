using EmployeeTaskService.Domain.Interfaces;
using MediatR;

namespace EmployeeTaskService.Application.Commands.Teams.UpdateTeam
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly ITeamRepository _teamRepository;

        public UpdateTeamCommandHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetByIdAsync(request.Id, cancellationToken);

            if (team == null)
                return false;

            var duplicatedName = await _teamRepository.ExistsByNameAsync(request.Name.Trim(), request.Id, cancellationToken);

            if (duplicatedName)
                throw new InvalidOperationException("Ya existe otro equipo con ese nombre.");

            team.Name = request.Name.Trim();
            team.Description = request.Description?.Trim();
            team.Active = request.Active;

            await _teamRepository.UpdateAsync(team, cancellationToken);
            await _teamRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}