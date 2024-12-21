using Core.Persistence.Repositories;

namespace SMS.Domain.Entities;

public class Faculty : Entity<int>
{
    public string Name { get; set; }
    public ICollection<Department> Departments { get; set; }
}