using EmployeeTaskService.Domain.Entities;
using EmployeeTaskService.Domain.Interfaces;
using EmployeeTaskService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskService.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
        }

        public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByLegajoAsync(string legajo, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AnyAsync(x => x.Legajo == legajo, cancellationToken);
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AnyAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<List<Employee>> GetFilteredAsync(Guid? teamId, bool? active, string? search, CancellationToken cancellationToken)
        {
            var query = _context.Employees
                .Include(x => x.Team)
                .AsNoTracking()
                .AsQueryable();

            if (teamId.HasValue)
            {
                query = query.Where(x => x.TeamId == teamId.Value);
            }

            if (active.HasValue)
            {
                query = query.Where(x => x.Active == active.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim().ToLower();

                query = query.Where(x =>
                    x.FirstName.ToLower().Contains(searchTerm) ||
                    x.LastName.ToLower().Contains(searchTerm) ||
                    x.Email.ToLower().Contains(searchTerm) ||
                    x.Legajo.ToLower().Contains(searchTerm));
            }

            return await query
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetByIdWithTeamAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(x => x.Team)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsByLegajoAsync(string legajo, Guid excludeId, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AnyAsync(x => x.Legajo == legajo && x.Id != excludeId, cancellationToken);
        }

        public async Task<bool> ExistsByEmailAsync(string email, Guid excludeId, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AnyAsync(x => x.Email == email && x.Id != excludeId, cancellationToken);
        }

        public Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            return Task.CompletedTask;
        }
    }
}