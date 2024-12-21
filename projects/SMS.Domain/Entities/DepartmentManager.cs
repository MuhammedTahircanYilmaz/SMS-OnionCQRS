namespace SMS.Domain.Entities;

public class DepartmentManager : UserEntity
{
    public long DepartmentId { get; set; }
    public Department Department { get; set; }
}