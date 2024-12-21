namespace SMS.Domain.Entities;

public class Instructor : UserEntity
{
    public List<Course>? Courses { get; set; }
    public List<Student>? Consultee { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}