using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TelerikEmployeeManagement.Models.Models;
using TelerikEmployeeManagement.Repositories.Repositories;
using TelerikEmployeeManagement.Web.ViewModels;

namespace TelerikEmployeeManagement.Web.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IDepartmentRepository _DepartmentRepository;

        public EmployeeController(IEmployeeRepository EmployeeRepository, IDepartmentRepository DepartmentRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _DepartmentRepository = DepartmentRepository;
        }
        [Route("listing-simple")]
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            employeeViewModel.AllEmployees = await employeeViewModel.GetAllEmployees();
            employeeViewModel.AllDepartment = await employeeViewModel.GetAllDepartments();
            var list = await _EmployeeRepository.GetEmployees();
            return View(employeeViewModel);
        }

        [Route("listing-simple")]
        [HttpPost]
        public async Task<IActionResult> Index(Employee employee, IFormFile PhotoPath)
        {

            if (PhotoPath != null && PhotoPath.Length > 0)
            {
                var path = Path.Combine(
                     Directory.GetCurrentDirectory(),
                     "wwwroot", PhotoPath.FileName);
                employee.PhotoPath = PhotoPath.FileName;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await PhotoPath.CopyToAsync(stream);
                }
            }
            if (employee.EmployeeId == Guid.Empty)
                await _EmployeeRepository.AddEmployee(employee);
            else
                await _EmployeeRepository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [Route("listing-mvc")]
        public async Task<IActionResult> ListingMVC()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            employeeViewModel.AllEmployees = await employeeViewModel.GetAllEmployees();
            employeeViewModel.AllDepartment = await employeeViewModel.GetAllDepartments();
            var list = await _EmployeeRepository.GetEmployees();
            return View(employeeViewModel);
        }


        [Route("listing-mvc")]
        [HttpPost]
        public async Task<IActionResult> ListingMVC(Employee Employee, IFormFile? PhotoPath)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null && PhotoPath.Length > 0)
                {
                    var path = Path.Combine(
                         Directory.GetCurrentDirectory(),
                         "wwwroot", PhotoPath.FileName);
                    Employee.PhotoPath = PhotoPath.FileName;
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await PhotoPath.CopyToAsync(stream);
                    }
                }

                if (Employee != null)
                {
                    if (Employee.EmployeeId == Guid.Empty)
                        await _EmployeeRepository.AddEmployee(Employee);
                    else
                        await _EmployeeRepository.UpdateEmployee(Employee);
                }
            }
            return RedirectToAction("ListingMVC");
        }

        [Route("listing-telerik")]
        public async Task<IActionResult> ListingTelerik()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            //employeeViewModel.AllEmployees = await employeeViewModel.GetAllEmployees();
            #region "millions records"
            var employeesList = new List<Employee>();
            for (int i = 0; i < 100000; i++)
            {
                var emp = new Employee
                {
                    FirstName = $"FirstName-{i.ToString()}",
                    LastName = $"LastName-{i.ToString()}",
                    Email = $"Email-{i.ToString()}@email.com",
                    DateOfBrith = DateTime.Now,
                    Gender = TelerikEmployeeManagement.Models.Enums.Gender.Male,
                };
                employeesList.Add(emp);
            }
            employeeViewModel.AllEmployees = employeesList;
            #endregion "millions records"
            employeeViewModel.AllDepartment = await employeeViewModel.GetAllDepartments();
            var list = await _EmployeeRepository.GetEmployees();
            return View(employeeViewModel);
        }


        [Route("listing-telerik")]
        [HttpPost]
        public async Task<IActionResult> ListingTelerik(Employee Employee, IFormFile? PhotoPath)
        {
            if (ModelState.IsValid)
            {
                if (PhotoPath != null && PhotoPath.Length > 0)
                {
                    var path = Path.Combine(
                         Directory.GetCurrentDirectory(),
                         "wwwroot", PhotoPath.FileName);
                    Employee.PhotoPath = PhotoPath.FileName;
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await PhotoPath.CopyToAsync(stream);
                    }
                }

                if (Employee != null)
                {
                    if (Employee.EmployeeId == Guid.Empty)
                        await _EmployeeRepository.AddEmployee(Employee);
                    else
                        await _EmployeeRepository.UpdateEmployee(Employee);
                }
            }
            return RedirectToAction("ListingTelerik");
        }

        [Route("DeleteEmployee")]
        [HttpGet]
        public async Task DeleteEmployee(Guid EmployeeId)
        {
            await _EmployeeRepository.DeleteEmployee(EmployeeId);
        }

        [Route("EditEmployee")]
        [HttpGet]
        public async Task<PartialViewResult> EditEmployee(Guid EmployeeId, bool isTelerik = false)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            employeeViewModel.AllEmployees = await employeeViewModel.GetAllEmployees();
            employeeViewModel.AllDepartment = await employeeViewModel.GetAllDepartments();
            employeeViewModel.Employee = employeeViewModel.AllEmployees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            if (!isTelerik)
            {

                return PartialView("_EditView", employeeViewModel);
            }
            else
            {
                return PartialView("_EditViewTelerik", employeeViewModel);
            }
        }

        [HttpGet]
        [Route("RenderEditEmployee")]
        public async Task<PartialViewResult> RenderEditEmployee(Guid employeeId)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            employeeViewModel.AllEmployees = await employeeViewModel.GetAllEmployees();
            employeeViewModel.AllDepartment = await employeeViewModel.GetAllDepartments();
            employeeViewModel.Employee = employeeViewModel.AllEmployees.FirstOrDefault(x => x.EmployeeId == employeeId);
            return PartialView("_EditViewTelerik", employeeViewModel);
        }

        [HttpPost]
        [Route("Employee_Read")]
        public async Task<ActionResult> Employee_Read([DataSourceRequest] DataSourceRequest request)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(_EmployeeRepository, _DepartmentRepository);
            IQueryable<Employee> employees = employeeViewModel.GetAllEmployeesQuery();
            var result = await employees.ToDataSourceResultAsync(request);
            return Json(result);

        }

    }
}
