using Microsoft.Extensions.DependencyInjection;
using Shcool.Infrustructure.Abstract;
using Shcool.Infrustructure.InfrustractureBaseces;
using Shcool.Infrustructure.IRepositories;
using Shcool.Infrustructure.Repositories;

namespace Shcool.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepositories, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();

            services.AddTransient(typeof(IGenaricRepos<>), typeof(GenaricRepos<>));

            return services;
        }
    }
}
