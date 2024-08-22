using EmployeeManeger.Application.CQRS.Commands.Create;
using EmployeeManeger.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManeger.Tests.Commands
{
    public class EmployeeCreateCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task EmployeeCreateCommandHandler_Success()
        {
            var handler = new EmployeeCreateCommandHandler(employeeRepository);
            var name = "Jo";
            uint age = 90;
            var post = "вау";
            double salary= 9000;
            DateTime dateOfMemory = DateTime.Now;

            var id = await handler.Handle(
                new EmployeeCreateComand
                {
                    Name = name,
                    Age = age,
                    Post = post,
                    Salary = salary,
                    DateOfMemory = dateOfMemory
                },
                CancellationToken.None);
            Assert.NotNull(
                await context.Employees.SingleOrDefaultAsync(em =>
                    em.Id == id && em.Name == name && em.Age == age && em.Post == post
                    && em.Salary == salary && em.DateOfMemory == dateOfMemory));
        }
    }
}
