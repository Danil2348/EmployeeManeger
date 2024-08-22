using EmployeeManeger.Application.CQRS.Commands.Update;
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
    public class EmployeeUpdateCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task EmployeeUpdateCommandHandler_Success()
        {
            // Arrange
            var handler = new EmployeeUpdateCommandHandler(employeeRepository);
            
            var name = "Jo";
            uint age = 92;
            var post = "вау";
            double salary = 18000;

            // Act
            await handler.Handle(new EmployeeUpdateCommand
            {
                Id=DataContextFactory.EmployeeIdForUpdate,
                Name = name,
                Age = age,
                Post = post,
                Salary = salary,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await context.Employees.SingleOrDefaultAsync(em =>
                em.Id == DataContextFactory.EmployeeIdForUpdate && em.Name == name 
                && em.Age == age && em.Post == post&& em.Salary == salary));
        }
    }
}
