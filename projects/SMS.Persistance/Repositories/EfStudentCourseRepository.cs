using Core.Persistence.Repositories;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Persistance.DbContexts;

namespace SMS.Persistance.Repositories;

public class EfStudentCourseRepository(BaseDbContext context) : EfRepositoryBase<StudentCourse, Guid, BaseDbContext>(context) ,
    IStudentCourseRepository
{
    
}