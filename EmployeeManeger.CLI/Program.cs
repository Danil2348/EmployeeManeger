using EmployeeManeger.Application;
using EmployeeManeger.CLI.Commands;
using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence;
using EmployeeManeger.Persistence.Data;
using EmployeeManeger.Persistence.DependencyInjections;
using EmployeeManeger.Persistence.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EmployeeManeger.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();
            services.InjectApplicationDependencies();
            services.InjectPersistenceDependenciesContext(configuration);
            services.InjectPersistenceDependenciesInterfaceAndRealization();
            services.AddTransient<IEmployeeCLI, EmployeeCLI>();
            var serviceProvider = services.BuildServiceProvider();
            var employeeCLI = serviceProvider.GetRequiredService<IEmployeeCLI>();
            var menu = new Menu(employeeCLI);
            menu.Run();
        }
    }
}
