using Core.Persistence.Repositories;

namespace SMS.Domain.Entities;

public class StudentCourse : Entity<Guid>
{
    public Student Student { get; set; }
    public Guid StudentId { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public string Semester { get; set; }
    public Status Status { get; set; }
}