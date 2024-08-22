using EmployeeManeger.Application.CQRS.Queries.GetAll;
using EmployeeManeger.CLI.Commands;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.CLI
{
    public class Menu
    {
        private readonly IEmployeeCLI _employeeCLI;

        public Menu(IEmployeeCLI employeeCLI)
        {
            _employeeCLI = employeeCLI;
        }
        public void Run()
        {
            while (true)
            {
                string choice = ClientMenu();

                switch (choice)
                {
                    case "1":
                        _employeeCLI.AddEmployee();
                        break;
                    case "2":
                        _employeeCLI.UpdateEmployee();
                        break;
                    case "3":
                        _employeeCLI.DeleteEmployee();
                        break;
                    case "4":
                        _employeeCLI.GetEmployee();
                        break;
                    case "5":
                        _employeeCLI.GetEmployees();
                        break;
                    case "6":
                        _employeeCLI.GetEmployeeSalary();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        private static string ClientMenu()
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Обновить данные сотрудника");
            Console.WriteLine("3. Удалить сотрудника");
            Console.WriteLine("4. Найти сотрудника по имени");
            Console.WriteLine("5. Показать всех сотрудников");
            Console.WriteLine("6. Рассчитать зарплату сотрудника");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();
            return choice;
        }
    }
}
