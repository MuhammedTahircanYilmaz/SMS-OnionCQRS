using Core.Persistence.Repositories;
using SMS.Domain.Entities;

namespace SMS.Application.Interfaces;

public interface IDepartmentRepository : IAsyncRepository<Department, long>
{
    
}