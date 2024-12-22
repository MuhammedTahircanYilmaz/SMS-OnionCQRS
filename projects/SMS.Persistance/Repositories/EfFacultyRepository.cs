using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfFacultyRepository(BaseDbContext context) : EfRepositoryBase<Faculty, int, BaseDbContext>(context), IFacultyRepository
{
    
}