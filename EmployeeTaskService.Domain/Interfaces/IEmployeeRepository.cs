using EmployeeTaskService.Domain.Entities;

namespace EmployeeTaskService.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Employee?> GetByIdWithTeamAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsByLegajoAsync(string legajo, CancellationToken cancellationToken);
        Task<bool> ExistsByLegajoAsync(string legajo, Guid excludeId, CancellationToken cancellationToken);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> ExistsByEmailAsync(string email, Guid excludeId, CancellationToken cancellationToken);
        Task<List<Employee>> GetFilteredAsync(Guid? teamId, bool? active, string? search, CancellationToken cancellationToken);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}