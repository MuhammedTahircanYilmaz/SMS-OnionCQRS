using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        
        builder.HasKey(d => d.Id).HasName("Id");
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();
        builder.Property(d=>d.FacultyId).HasColumnName("FacultyId").IsRequired();
        builder.Property(d=>d.DepartmentManagerId).HasColumnName("DepartmentManagerId").IsRequired();
        
        builder.HasOne(d => d.Faculty)
            .WithMany(p => p.Departments)
            .HasForeignKey(d => d.FacultyId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(d=> d.DepartmentManager)
            .WithOne(p => p.Department)
            .HasForeignKey<Department>(d => d.DepartmentManagerId)
            .OnDelete(DeleteBehavior.NoAction);

        
        builder.HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        
        builder.HasMany(d=>d.Courses)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        
        builder.HasMany(d=>d.Instructors)
            .WithOne(i => i.Department)
            .HasForeignKey(i => i.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        
        
        builder.Navigation(d => d.DepartmentManager).AutoInclude();
        builder.Navigation(d=>d.Faculty).AutoInclude();
        builder.Navigation(d=>d.Courses).AutoInclude();
        builder.Navigation(d=>d.Students).AutoInclude();
        builder.Navigation(d=>d.Instructors).AutoInclude();
    }
}