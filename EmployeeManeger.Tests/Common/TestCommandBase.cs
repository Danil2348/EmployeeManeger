using EmployeeManeger.Domain.Entities;
using EmployeeManeger.Persistence.Data;
using EmployeeManeger.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManeger.Tests.Common
{
    public abstract class TestCommandBase: IDisposable
    {
        protected readonly DataContext context;
        protected readonly EmployeeRepository employeeRepository;

        public TestCommandBase()
        {
            context = DataContextFactory.Create();
        }
        public void Dispose()
        {
            DataContextFactory.Destroy(context);
        }
    }
}
