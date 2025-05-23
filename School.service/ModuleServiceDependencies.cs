using Microsoft.Extensions.DependencyInjection;
using School.service.Abstracts;
using School.service.Implementations;

namespace School.service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddSeeviceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }

    }
}
