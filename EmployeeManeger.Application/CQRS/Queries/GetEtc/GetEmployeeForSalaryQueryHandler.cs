using EmployeeManeger.Application.Exeptions;
using EmployeeManeger.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManeger.Application.CQRS.Queries.GetEtc
{
    public class GetEmployeeForSalaryQueryHandler: IRequestHandler<GetEmployeeForSalaryQuery, double>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeForSalaryQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<double> Handle(GetEmployeeForSalaryQuery request, CancellationToken cancellationToken)
        {
            if (await _employeeRepository.GetEmployee(request.Name) == null || request == null)
                throw new NotFoundExeption();

            if (request.StartDate < request.EndDate)
                throw new NotDataExeption();

            var employee = _employeeRepository.GetEmployee(request.Name).Result;

            if(request.StartDate<employee.DateOfMemory)
                throw new NotDataExeption();

            return CalculateSalary(employee, request.StartDate, request.EndDate); ;

        }

        static double CalculateSalary(Employee employee, DateTime startDate, DateTime endDate)
        {
            int workingDaysInMonth = CountWorkingDays(new DateTime(startDate.Year, startDate.Month, 1),
                                                        new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month)));

            int workingDays = CountWorkingDays(startDate, endDate);

            return (employee.Salary / workingDaysInMonth) * workingDays;
        }

        static int CountWorkingDays(DateTime start, DateTime end)
        {
            int workingDays = 0;
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            return workingDays;
        }
    }
}
