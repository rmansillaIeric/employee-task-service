using EmployeeTaskService.Domain.Entities;
using EmployeeTaskService.Domain.Interfaces;
using EmployeeTaskService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskService.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Team team, CancellationToken cancellationToken)
        {
            await _context.Teams.AddAsync(team, cancellationToken);
        }

        public async Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Teams
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Teams
                .AnyAsync(x => x.Name == name, cancellationToken);
        }

        public async Task<List<Team>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Teams
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Team?> GetByIdWithEmployeesAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Teams
                .Include(x => x.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
