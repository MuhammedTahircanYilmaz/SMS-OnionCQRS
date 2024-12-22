using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application.Interfaces;
using SMS.Persistance.DbContexts;
using SMS.Persistance.Repositories;

namespace SMS.Persistance;

public static class PersistanceDependenciesRegistration
{

    public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
        });

        services.AddScoped<ICourseRepository, EfCourseRepository>();
        services.AddScoped<IStudentRepository, EfStudentRepository>();
        services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
        services.AddScoped<IDepartmentManagerRepository, EfDepartmentManagerRepository>();
        services.AddScoped<IFacultyRepository, EfFacultyRepository>();
        services.AddScoped<IInstructorRepository, EfInstructorRepository>();
        services.AddScoped<IStudentCourseRepository, EfStudentCourseRepository>();

        return services;
    }
}