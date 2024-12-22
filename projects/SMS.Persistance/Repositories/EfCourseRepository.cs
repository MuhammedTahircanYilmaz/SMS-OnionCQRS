using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfCourseRepository(BaseDbContext context)
    : EfRepositoryBase<Course, Guid, BaseDbContext>(context), ICourseRepository;