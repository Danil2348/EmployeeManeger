using EmployeeManeger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Persistence.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(
                 new Employee
                 {
                     Name = "John",
                     Age=18,
                     Post="Директор",
                     Salary=50000.56,
                     DateOfMemory=DateTime.Now
                 }
            );
        }
    }
}
