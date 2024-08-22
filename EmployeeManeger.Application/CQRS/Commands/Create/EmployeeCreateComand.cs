using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Commands.Create
{
    public class EmployeeCreateComand: IRequest<Guid>
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Post { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfMemory { get; set; }

    }
}
