using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSBiro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public static List<Position> positions = new List<Position>
        {
            new Position {Id=1, Name="PLC Programmer", PayRank=50000, Obsolete=false },
            new Position {Id=2, Name="Junior Developer", PayRank=10000, Obsolete=false }
        };

        public static List<Employee> employees = new List<Employee>
        {
            new Employee {Id=1, Obsolete=false, Brutto2=10000, Contract="Contract" , EmploymentEnded=false, 
                FirstName="Nikola", LastName="Lovrić", IBAN="ibanNikola", PaidOvertime=false, Position=positions[0]},
            new Employee {Id=2, Obsolete=false, Brutto2=10000, Contract="Contract2" , EmploymentEnded=false,
                FirstName="Danijel", LastName="Pavić", IBAN="ibanDanijel", PaidOvertime=false, Position=positions[1]},
        };

        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployees() //returns all employees via api
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var employee = employees.FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
            {
                return NotFound("Sorry - no employee ^^");
            }
            return Ok(employee);
        }

    };
}
