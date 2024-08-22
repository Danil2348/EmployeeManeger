using EmployeeManeger.Application.CQRS.Commands.Create;
using EmployeeManeger.Application.CQRS.Commands.Delete;
using EmployeeManeger.Application.CQRS.Commands.Update;
using EmployeeManeger.Application.CQRS.Queries.GetAll;
using EmployeeManeger.Application.CQRS.Queries.GetDetail;
using EmployeeManeger.Application.CQRS.Queries.GetEtc;
using EmployeeManeger.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManeger.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employees = await _mediator.Send(new GetEmployeesAllQueryHandler());
            return Ok(employees);
        }

        [HttpGet("{Name}")]
        public async Task<ActionResult<Employee>> GetEmployee(string Name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Name = Name });
            return Ok(employee);
        }

        [HttpGet("{Name}/Salary")]
        public async Task<ActionResult<double>> GetEmployeeSalary(string Name, DateTime StartDate, DateTime EndDate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var salary = await _mediator.Send(new GetEmployeeForSalaryQuery { Name = Name, StartDate = StartDate, EndDate = EndDate });
           
            return Ok(salary);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeCreateComand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(EmployeeUpdateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _mediator.Send(new EmployeeDelteCommand { Id = id });
            return Ok();
        }
    }
}
