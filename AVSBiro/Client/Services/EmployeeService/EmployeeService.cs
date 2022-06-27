using AVSBiro.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace AVSBiro.Client.Services.Employee_service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public EmployeeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Position> Positions { get; set; } = new List<Position>();

        public async Task CreateEmployee(Employee employee)
        {
            var result = await _http.PostAsJsonAsync("api/employees", employee);
            await SetEmployees(result);
        }

        private async Task SetEmployees(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Employee>>();
            Employees = response;
            _navigationManager.NavigateTo("employees");
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var result = await _http.PutAsJsonAsync($"api/employee/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _http.DeleteAsync($"api/employee/{id}");
            await SetEmployees(result);
        }

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/employee");
            if(result!=null)
                Employees = result;
        }

        public async Task GetPositions()
        {
            var result = await _http.GetFromJsonAsync<List<Position>>("api/superemployee/Positions");
            if (result != null)
                Positions = result;
        }

        public async Task<Employee> GetSingleEmployee(int id)
        {
            var result = await _http.GetFromJsonAsync<Employee>($"api/employee/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found!");
        }
    }
}
