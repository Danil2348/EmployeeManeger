using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence.Data;
using EmployeeManeger.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManeger.Persistence
{
    public static class DependencyInjectionContext
    {
        public static IServiceCollection InjectPersistenceDependenciesContext (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}