using EmployeeManeger.Application.Exeptions;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Update
{
    public class EmployeeUpdateCommandHandler: IRequestHandler<EmployeeUpdateCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetEmployee(request.Id) == null || request==null)
                throw new NotFoundExeption();

            var employee = new Employee
            {
                Id=request.Id,
                Name = request.Name,
                Age = request.Age,
                Post = request.Post,
                Salary = request.Salary
            };
            if (!_employeeRepository.UpdateEmployeeAsync(employee).Result)
                throw new NotSavedExeption();

            return Unit.Value;
        }
    }
}
