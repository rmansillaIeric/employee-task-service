using EmployeeTaskService.Domain.Entities;

namespace EmployeeTaskService.Domain.Interfaces
{
    public interface ITeamRepository
    {
        Task AddAsync(Team team, CancellationToken cancellationToken);
        Task<Team?> GetByIdWithEmployeesAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
        Task<List<Team>> GetAllAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}