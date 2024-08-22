using EmployeeManeger.Application.CQRS.Queries.GetDetail;
using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManeger.Tests.Queries
{
    public class GetEmployeeByIdQueryHandlerTests: TestCommandBase
    {
        [Fact]
        public async Task GetEmployeeByIdQueryHandler_Success()
        {
            // Arrange
            var handler = new GetEmployeeByIdQueryHandler(employeeRepository);

            // Act
            var result = await handler.Handle(
                new GetEmployeeByIdQuery
                {
                    Name = DataContextFactory.Name
                },
                CancellationToken.None); ;

            // Assert
            result.ShouldBeOfType<Employee>();
            result.Name.ShouldBe("John");

        }
    }
}
