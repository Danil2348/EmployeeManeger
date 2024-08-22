using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EmployeeManeger.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectApplicationDependencies(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
