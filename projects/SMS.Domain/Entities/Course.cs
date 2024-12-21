using Core.Persistence.Repositories;

namespace SMS.Domain.Entities;

public sealed class Course : Entity<Guid>
{
    public string CourseCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public long DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
    public ICollection<Instructor> Instructors { get; set; } = null!;
}