using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentManagerConfiguration : IEntityTypeConfiguration<DepartmentManager>
{
    public void Configure(EntityTypeBuilder<DepartmentManager> builder)
    {
        builder.ToTable("DepartmentManagers");

        builder.HasKey(dm => dm.Id).HasName("Id");

        builder.Property(dm => dm.DepartmentId)
            .HasColumnName("DepartmentId")
            .IsRequired();

        builder.HasOne(dm => dm.Department)
            .WithOne(d => d.DepartmentManager)
            .HasForeignKey<DepartmentManager>(dm => dm.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(dm => dm.Department).AutoInclude();
    }
}
