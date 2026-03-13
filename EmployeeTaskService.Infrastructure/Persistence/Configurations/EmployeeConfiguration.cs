using EmployeeTaskService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTaskService.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Legajo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.FechaIngreso)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.HasIndex(x => x.Legajo)
                .IsUnique();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasOne(x => x.Team)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}