using AVSBiro.Shared;

namespace AVSBiro.Client.Services.Employee_service
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        List<Position> Positions { get; set; }
        Task GetPositions();
        Task GetEmployees();
        Task<Employee> GetSingleEmployee(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
