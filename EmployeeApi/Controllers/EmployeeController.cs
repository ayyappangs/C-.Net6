using EmployeeApi.Command;
using EmployeeApi.Model;
using EmployeeApi.Query;
using EmployeeApi.Validations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediatR;
        private readonly IEmployeeValidator employeeValidator;

        public EmployeeController(IMediator mediatR, IEmployeeValidator employeeValidator)
        {
            this.mediatR = mediatR;
            this.employeeValidator = employeeValidator;
        }

        
        [HttpGet("Employees")]
        public async Task<IActionResult> Employees()
        {
            List<Employee>? result = await mediatR.Send(new GetEmployeesQuery());
            return Ok(result);
        }

        
        [HttpPost("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee([FromBody] Employee employee)
        {
            try
            {
                if (!employeeValidator.IsValidEmployee(employee))
                {
                    return BadRequest(employee);
                }
          
                var result = await mediatR.Send(new AddEmployeeCommand(employee.EmployeeId, employee.FirstName, employee.LastName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.StackTrace);
            }
        }
    }
}
