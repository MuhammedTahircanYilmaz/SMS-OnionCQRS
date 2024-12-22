using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfDepartmentManagerRepository(BaseDbContext context) :
    EfRepositoryBase<DepartmentManager,Guid,BaseDbContext>(context), IDepartmentManagerRepository
{
    
}