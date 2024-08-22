using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Domain.Entities
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid Id);
        Task<Employee> GetEmployee(string Name);
        Task<bool> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Employee employee);
        Task<bool> Save();
    }
}
