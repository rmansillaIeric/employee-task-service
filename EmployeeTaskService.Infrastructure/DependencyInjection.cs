using EmployeeTaskService.Domain.Interfaces;
using EmployeeTaskService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTaskService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}