using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Persistence.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            await _context.AddAsync(employee);
            return await Save();
        }

        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            _context.Remove(employee);
            return await Save();
        }

        public async Task<Employee> GetEmployee(Guid Id)
        {
            return await _context.Employees.FirstOrDefaultAsync(em => em.Id == Id);
        }

        public async Task<Employee> GetEmployee(string Name)
        {
            return await _context.Employees.FirstOrDefaultAsync(em=>em.Name==Name);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _context.Update(employee);
            return await Save();
        }
    }
}
