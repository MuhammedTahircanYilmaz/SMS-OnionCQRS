using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id).HasName("Id");

        builder.Property(s => s.StudentIdNumber)
            .HasColumnName("StudentIdNumber")
            .IsRequired();

        builder.Property(s => s.Gpa)
            .HasColumnName("Gpa")
            .IsRequired();

        builder.Property(s => s.YearOfStudy)
            .HasColumnName("YearOfStudy")
            .IsRequired();

        builder.Property(s => s.AdvisorId)
            .HasColumnName("AdvisorId")
            .IsRequired();

        builder.Property(s => s.DepartmentId)
            .HasColumnName("DepartmentId")
            .IsRequired();

        builder.HasOne(s => s.Advisor)
            .WithMany(i => i.Advisee)
            .HasForeignKey(s => s.AdvisorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(s => s.Department)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity<Dictionary<string, object>>(
                "StudentCourses",
                j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId")
            );

        builder.Navigation(s => s.Courses).AutoInclude();
        builder.Navigation(s => s.Advisor).AutoInclude();
        builder.Navigation(s => s.Department).AutoInclude();
    }
}

