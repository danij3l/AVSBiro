using AVSBiro.Shared;
using System.Net.Http.Json;

namespace AVSBiro.Client.Services.Employee_service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Position> Positions { get; set; } = new List<Position>();

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/employee");
            if(result!=null)
                Employees = result;
        }

        public Task GetPositions()
        {
            throw new NotImplementedException();
        }

        public Task GetSimgleEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
