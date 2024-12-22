using Core.Persistence.Repositories;
using SMS.Domain.Entities;

namespace SMS.Application.Interfaces;

public interface IStudentCourseRepository : IAsyncRepository<StudentCourse, Guid>
{
    
}