using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportShoes.Models;

namespace SportShoes.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _usersManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolesManager;
        public AccountManagerController(UserManager<ApplicationUser> _usersManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> rolesManager)
        {
            this._usersManager = _usersManager;
            this._signInManager = _signInManager;
            this._rolesManager = rolesManager;
        }
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            //return RedirectToAction("Login", "Account");
            return Redirect(returnUrl);
        }
        public IActionResult Roles()
        {
            var roles = _rolesManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRoles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles(IdentityRole model)
        {
            if (!_rolesManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _rolesManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Roles");
        }

    }
}
