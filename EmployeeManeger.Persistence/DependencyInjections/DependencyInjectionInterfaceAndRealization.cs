using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Persistence.DependencyInjections
{
    public static class DependencyInjectionInterfaceAndRealization
    {
        public static IServiceCollection InjectPersistenceDependenciesInterfaceAndRealization(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
