using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfDepartmentRepository(BaseDbContext context) : 
    EfRepositoryBase<Department, long, BaseDbContext>(context), IDepartmentRepository 
{
    
}