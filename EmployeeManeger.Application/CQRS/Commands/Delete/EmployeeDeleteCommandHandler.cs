using EmployeeManeger.Application.Exeptions;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Delete
{
    public class EmployeeDeleteCommandHandler: IRequestHandler<EmployeeDelteCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDeleteCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(EmployeeDelteCommand request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetEmployee(request.Id) == null || request==null)
                throw new NotFoundExeption();
            var employee = new Employee
            {
                Id = request.Id
            };
            if (!_employeeRepository.DeleteEmployeeAsync(employee).Result)
                throw new NotSavedExeption();

            return Unit.Value;
        }
    }
}
