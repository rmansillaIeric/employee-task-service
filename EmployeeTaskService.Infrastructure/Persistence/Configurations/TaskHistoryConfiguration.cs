using EmployeeTaskService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTaskService.Infrastructure.Persistence.Configurations
{
    public class TaskHistoryConfiguration : IEntityTypeConfiguration<TaskHistory>
    {
        public void Configure(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("TaskHistories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fecha)
                .IsRequired();

            builder.Property(x => x.MovementType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Observations)
                .HasMaxLength(500);

            builder.Property(x => x.ActionUser)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.TaskItem)
                .WithMany()
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}