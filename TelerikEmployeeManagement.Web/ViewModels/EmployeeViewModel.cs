using TelerikEmployeeManagement.Models.Models;
using TelerikEmployeeManagement.Repositories.Repositories;

namespace TelerikEmployeeManagement.Web.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IDepartmentRepository _DepartmentRepository;

        public List<Employee> AllEmployees { get; set; }
        public List<Department> AllDepartment{ get; set; }

        public Employee Employee { get; set; } = new Employee();
        public Employee EditEmployee { get; set; } = new Employee();

        public EmployeeViewModel(IEmployeeRepository EmployeeRepository, IDepartmentRepository DepartmentRepository)
        {
            this._EmployeeRepository = EmployeeRepository;
            this._DepartmentRepository = DepartmentRepository;
            AllEmployees = new List<Employee>();
            AllDepartment = new List<Department>();
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return (await _EmployeeRepository.GetEmployees()).ToList();
        }

        public IQueryable<Employee> GetAllEmployeesQuery()
        {
            return _EmployeeRepository.GetEmployeesQuery();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return (await _DepartmentRepository.GetDepartments()).ToList();
        }
    }
}
