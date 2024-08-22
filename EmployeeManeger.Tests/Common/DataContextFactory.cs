using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Tests.Common
{
    public class DataContextFactory
    {
        public static string Name = "John";

        public static Guid EmployeeIdForDelete = Guid.NewGuid();
        public static Guid EmployeeIdForUpdate = Guid.NewGuid();

        public static DataContext Create()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DataContext(options);
            context.Database.EnsureCreated();
            context.Employees.AddRange(
                new Employee
                {
                    Name = "John",
                    Age = 18,
                    Post = "Директор",
                    Salary = 50000.56,
                    DateOfMemory = DateTime.Now
                },
                new Employee
                {
                    Name = "John2",
                    Age = 56,
                    Post = "Директор-старший",
                    Salary = 300000.56,
                    DateOfMemory = DateTime.Now
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
