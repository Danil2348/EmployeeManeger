using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Delete
{
    public class EmployeeDelteCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
