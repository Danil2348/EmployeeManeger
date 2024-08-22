using EmployeeManeger.Application.CQRS.Commands.Create;
using EmployeeManeger.Application.CQRS.Commands.Delete;
using EmployeeManeger.Application.CQRS.Commands.Update;
using EmployeeManeger.Application.CQRS.Queries.GetAll;
using EmployeeManeger.Application.CQRS.Queries.GetDetail;
using EmployeeManeger.Application.CQRS.Queries.GetEtc;
using MediatR;
using System;
using System.Reflection;

namespace EmployeeManeger.CLI.Commands
{
    public class EmployeeCLI: IEmployeeCLI
    {
        private readonly IMediator _mediator;

        public EmployeeCLI(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        public void AddEmployee()
        {
            Console.Write("Введите имя: ");
            var Name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            uint Age = (uint)int.Parse(Console.ReadLine());
            Console.Write("Введите Должность: ");
            var Post = Console.ReadLine();
            Console.Write("Введите зарплату: ");
            double Salary = double.Parse(Console.ReadLine());
            Console.Write("Введите дату: ");
            DateTime DateOfMemory = DateTime.Parse(Console.ReadLine());
            _mediator.Send(new EmployeeCreateComand
            {
                Name = Name,
                Age = Age,
                Post = Post,
                Salary = Salary,
                DateOfMemory = DateOfMemory
            });
        }

        public void DeleteEmployee()
        {
            Console.Write("Введите Id сотрудника: ");
            Guid Id = Guid.Parse(Console.ReadLine());
            _mediator.Send(new EmployeeDelteCommand { Id = Id });
        }

        public void GetEmployee()
        {
            Console.Write("Введите имя сотрудника: ");
            string Name = Console.ReadLine();
            var employee = _mediator.Send(new GetEmployeeByIdQuery { Name=Name}).Result;

            PropertyInfo[] properties = employee.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(employee);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }

        public void GetEmployees()
        {
            var employees = _mediator.Send(new GetEmployeesAllQuery()).Result;
            foreach (var employee in employees)
            {
                PropertyInfo[] properties = employee.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(employee);
                    Console.WriteLine($"{property.Name}: {value}");
                }
                Console.WriteLine("");
            }
        }

        public void GetEmployeeSalary()
        {
            Console.Write("Введите имя сотрудника: ");
            string Name = Console.ReadLine();
            Console.Write("Введите начальную дату: ");
            DateTime StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите конечную дату: ");
            DateTime EndDate = DateTime.Parse(Console.ReadLine());
            double salary=_mediator.Send(new GetEmployeeForSalaryQuery {Name=Name, StartDate=StartDate, EndDate=EndDate}).Result;
            Console.WriteLine("За данный период зарплата данного сотрудника состовляет: "+salary);
        }

        public void UpdateEmployee()
        {
            Console.Write("Введите Id сотрудника: ");
            Guid Id = Guid.Parse(Console.ReadLine());
            Console.Write("Введите имя: ");
            var Name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            uint Age = (uint)int.Parse(Console.ReadLine());
            Console.Write("Введите Должность: ");
            var Post = Console.ReadLine();
            Console.Write("Введите зарплату: ");
            double Salary = double.Parse(Console.ReadLine());
            _mediator.Send(new EmployeeUpdateCommand
            {
                Id = Id,
                Name = Name,
                Age = Age,
                Post = Post,
                Salary = Salary
            });
        }
    }
}
