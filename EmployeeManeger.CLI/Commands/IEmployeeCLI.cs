using EmployeeManeger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.CLI.Commands
{
    public interface IEmployeeCLI
    {
        void GetEmployees();
        void GetEmployee();
        void GetEmployeeSalary();
        void AddEmployee();
        void UpdateEmployee();
        void DeleteEmployee();
    }
}
