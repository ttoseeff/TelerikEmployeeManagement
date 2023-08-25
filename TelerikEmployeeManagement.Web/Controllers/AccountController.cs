using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TelerikEmployeeManagement.Web.Models;
using TelerikEmployeeManagement.Web.ViewModels;

namespace TelerikEmployeeManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    var LoginUser = await _userManager.FindByEmailAsync(user.Email);

                    if (LoginUser != null)
                    {
                        var roles = await _userManager.GetRolesAsync(LoginUser);
                        if (roles.Count() > 0)
                        {
                            if (roles[0] == UserRole.Admin.ToString())
                            {
                                return RedirectToAction("listing-telerik", "Employee");
                            }
                            else if (roles[0] == UserRole.User.ToString())
                            {
                                return RedirectToAction("Index", "User");
                            }
                            else
                            {
                                return View();
                            }
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> SetAdminRole()
        {
            var roleExists = await _roleManager.RoleExistsAsync("Admin");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var user = await _userManager.FindByEmailAsync("toseef@toseef.com");

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Admin"); // Replace "User" with the actual role name
            }
            return View();
        }

        public async Task<IActionResult> SetUserRole()
        {
            var roleExists = await _roleManager.RoleExistsAsync("User");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            var user = await _userManager.FindByEmailAsync("ahmad@toseef.com");

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "User"); // Replace "User" with the actual role name
            }
            return View();
        }

    }
}
