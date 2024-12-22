using System.Reflection;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;

namespace SMS.Persistance.DbContexts;

public class BaseDbContext : DbContext
{

    public BaseDbContext(DbContextOptions<BaseDbContext> opt): base(opt)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>()
            .ToTable("UserEntities")
            .HasDiscriminator<string>("Discriminator")
            .HasValue<User>("User")
            .HasValue<UserEntity>("UserEntity");
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<DepartmentManager> DepartmentManagers { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }


    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    
}