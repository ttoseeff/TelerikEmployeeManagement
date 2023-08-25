using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TelerikEmployeeManagement.Repositories.Repositories;
using TelerikEmployeeManagement.Web.Models;

namespace TelerikEmployeeManagement.Web.Controllers
{
    [Authorize(Roles = nameof(UserRole.User))]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmployeeRepository _employeeRepository;

        public UserController(UserManager<IdentityUser> userManager, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _employeeRepository = employeeRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var Employee = await _employeeRepository.GetEmployeeByEmail(user?.Email);
            return View(Employee);
        }
    }
}
