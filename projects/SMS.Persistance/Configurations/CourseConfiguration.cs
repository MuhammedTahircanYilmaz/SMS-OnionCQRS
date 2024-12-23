using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(c => c.Id);
        builder.Property(c=>c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c=>c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c=>c.DepartmentId).HasColumnName("DepartmentId").IsRequired();
        builder.Property(c=>c.Credits).HasColumnName("Credits").IsRequired();
        builder.Property(c=>c.CourseCode).HasColumnName("CourseCode").IsRequired();
        
        builder.HasOne(c=>c.Department)
            .WithMany(c=>c.Courses)
            .HasForeignKey(c=>c.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Instructors).WithMany(I => I.Courses);
        builder.HasMany(c => c.Students).WithMany(s => s.Courses);
        
        builder.Navigation(x=>x.Students).AutoInclude();
        builder.Navigation(x=>x.Instructors).AutoInclude();
        
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

    }
}