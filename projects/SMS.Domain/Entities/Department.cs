using Core.Persistence.Repositories;

namespace SMS.Domain.Entities;

public class Department : Entity<long>
{
    public string Name { get; set; }
    public ICollection<Instructor>? Instructors { get; set; }
    public ICollection<Student>? Students { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public Guid DepartmentManagerId { get; set; }
    public DepartmentManager DepartmentManager { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}