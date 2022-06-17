using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSBiro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(sh => sh.Position).ToListAsync();
            return Ok(employees);
        }

        [HttpGet("positions")]
        public async Task<ActionResult<List<Position>>> GetPositions()
        {
            var positions = await _context.Postions.ToListAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Sorry, no employee here. :/");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            employee.Position = null;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee, int id)
        {
            var dbEmployee = await _context.Employees
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmployee == null)
                return NotFound("Sorry, but no employee.");

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.PositionId = employee.PositionId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmployee = await _context.Employees
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmployee == null)
                return NotFound("Sorry, but no employee.");

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }

        private async Task<List<Employee>> GetDbEmployees()
        {
            return await _context.Employees.Include(sh => sh.Position).ToListAsync();
        }
    }
}