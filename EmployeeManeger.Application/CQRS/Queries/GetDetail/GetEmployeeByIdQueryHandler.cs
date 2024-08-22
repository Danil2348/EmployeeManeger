using EmployeeManeger.Application.Exeptions;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Queries.GetDetail
{
    public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetEmployee(request.Name) == null || request==null)
                throw new NotFoundExeption();

            return _employeeRepository.GetEmployee(request.Name).Result;
        }
    }
}
