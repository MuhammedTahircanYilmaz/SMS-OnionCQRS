using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");

        builder.HasKey(i => i.Id).HasName("Id");

        builder.Property(i => i.DepartmentId)
            .HasColumnName("DepartmentId")
            .IsRequired();

        builder.HasOne(i => i.Department)
            .WithMany(d => d.Instructors)
            .HasForeignKey(i => i.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(i => i.Courses)
            .WithMany(c => c.Instructors);
            
        builder.HasMany(i => i.Advisee)
            .WithOne(s => s.Advisor)
            .HasForeignKey(s => s.AdvisorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(i => i.Courses).AutoInclude();
        builder.Navigation(i => i.Advisee).AutoInclude();
        builder.Navigation(i => i.Department).AutoInclude();
    }
}