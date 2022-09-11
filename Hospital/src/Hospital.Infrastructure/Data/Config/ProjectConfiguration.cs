using Hospital.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Data.Config
{
  public class ProjectConfiguration : IEntityTypeConfiguration<Calendar>
  {
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
      builder.Property(p => p.Name)
          .HasMaxLength(100)
          .IsRequired();

      builder.Property(p => p.Priority)
        .HasConversion(
            p => p.Value,
            p => PriorityStatus.FromValue(p));
    }
  }
}
