using TelerikEmployeeManagement.Models.Enums;
using TelerikEmployeeManagement.Models.Models;

namespace TelerikEmployeeManagement.Repositories.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> DeleteEmployee(Guid employeeId);
        Task<Employee> GetEmployee(Guid employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<Employee> UpdateEmployee(Employee employee);
    }
}