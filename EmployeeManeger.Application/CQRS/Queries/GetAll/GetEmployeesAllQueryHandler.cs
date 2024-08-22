using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Queries.GetAll
{
    public class GetEmployeesAllQueryHandler: IRequestHandler<GetEmployeesAllQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesAllQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetEmployeesAllQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployees();
        }
    }
}
