using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Queries.GetDetail
{
    public class GetEmployeeByIdQuery: IRequest<Employee>
    {
        public string Name { get; set; }
    }
}
