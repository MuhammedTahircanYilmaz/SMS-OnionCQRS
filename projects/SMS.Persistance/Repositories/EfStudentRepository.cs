using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfStudentRepository(BaseDbContext context)
    : EfRepositoryBase<Student, Guid, BaseDbContext>(context), IStudentRepository;