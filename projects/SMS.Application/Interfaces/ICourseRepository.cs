using Core.Persistence.Repositories;
using SMS.Domain.Entities;

namespace SMS.Application.Interfaces;

public interface ICourseRepository : IAsyncRepository<Course, Guid>
{
}