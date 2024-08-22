using EmployeeManeger.Application.CQRS.Commands.Delete;
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
    public class EmployeeDeleteCommandHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task EmployeeDeleteCommandHandler_Success()
        {
            var handler = new EmployeeDeleteCommandHandler(employeeRepository);

            await handler.Handle(new EmployeeDelteCommand
            {
                Id = DataContextFactory.EmployeeIdForDelete
            }, CancellationToken.None);

            Assert.Null(context.Employees.SingleOrDefaultAsync(em =>
                em.Id == DataContextFactory.EmployeeIdForDelete));
        }
    }
}
