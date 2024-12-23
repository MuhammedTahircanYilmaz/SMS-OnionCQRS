using SMS.Domain.Entities;

namespace SMS.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("UserEntities");

        builder.HasKey(u => u.Id).HasName("Id");

        builder.Property(u => u.TRIN)
            .HasColumnName("TRIN")
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(u => u.Birthday)
            .HasColumnName("Birthday")
            .IsRequired();

        builder.Property(u => u.Gender)
            .HasColumnName("Gender")
            .IsRequired();

        builder.Property(u => u.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("Email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.PasswordSalt)
            .HasColumnName("PasswordSalt")
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PasswordHash")
            .IsRequired();

        builder.Property(u => u.Status)
            .HasColumnName("Status")
            .IsRequired();

        builder.HasMany(u => u.UserOperationClaims)
            .WithOne()
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}