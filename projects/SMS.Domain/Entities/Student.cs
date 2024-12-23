namespace SMS.Domain.Entities;

public sealed class Student : UserEntity
{
    public int StudentIdNumber { get; set; }
    public float Gpa { get; set; }
    public string YearOfStudy { get; set; }
    public ICollection<Course>? Courses { get; set; }
    
    public Guid AdvisorId { get; set; }
    public Instructor? Advisor { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

}