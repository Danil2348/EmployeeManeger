using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Update
{
    public class EmployeeUpdateCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Post { get; set; }
        public double Salary { get; set; }
    }
}
