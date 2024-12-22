using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfInstructorRepository(BaseDbContext context)
    : EfRepositoryBase<Instructor, Guid, BaseDbContext>(context), IInstructorRepository;