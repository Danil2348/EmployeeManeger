using EmployeeManeger.Application.CQRS.Queries.GetAll;
using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EmployeeManeger.Tests.Queries
{
    public class GetEmployeesAllQueryHandlerTests: TestCommandBase
    {
        [Fact]
        public async void GetEmployeesAllQueryHandler_Success()
        {
            var handler = new GetEmployeesAllQueryHandler(employeeRepository);
            var result = await handler.Handle(
                new GetEmployeesAllQuery { }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<Employee>>();
            result.Count.ShouldBe(2);
        }
    }
}
