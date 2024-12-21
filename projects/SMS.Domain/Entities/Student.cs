namespace SMS.Domain.Entities;

public sealed class Student : UserEntity
{
    public Guid StudentId { get; set; }
    public float Gpa { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public Instructor? Advisor { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

}