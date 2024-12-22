using Core.Persistence.Repositories;

namespace SMS.Domain.Entities;

public class Grade : Entity<Guid>
{
    public Guid StudentCourseId { get; set; }
    public StudentCourse StudentCourse { get; set; }
    public float GradeValue { get; set; }
}