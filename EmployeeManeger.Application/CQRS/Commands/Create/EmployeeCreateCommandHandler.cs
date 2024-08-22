using EmployeeManeger.Application.Exeptions;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Create
{
    public class EmployeeCreateCommandHandler: IRequestHandler<EmployeeCreateComand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Handle(EmployeeCreateComand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NotFoundExeption();
            
            var employeedb=_employeeRepository.GetEmployees().Result.Where(ep => ep.Name.Trim().ToUpper() == request.Name.TrimEnd().ToUpper()).FirstOrDefault();
            
            if (employeedb != null)
                throw new NotUniqueExeption();

            var employee = new Employee
            {
                Name = request.Name,
                Age = request.Age,
                Post = request.Post,
                Salary = request.Salary,
                DateOfMemory = request.DateOfMemory
            };

            if(!_employeeRepository.CreateEmployeeAsync(employee).Result)
            {
                throw new NotSavedExeption();
            }
            return employee.Id;
        }
    }
}
