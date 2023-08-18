using TelerikEmployeeManagement.Models.Models;

namespace TelerikEmployeeManagement.Repositories.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartment(Guid departmentId);
        Task<IEnumerable<Department>> GetDepartments();
    }
}