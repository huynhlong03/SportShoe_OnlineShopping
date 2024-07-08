using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SportShoes.Models;
using SportShoes.Models.ViewModel;
using test.Models;


namespace SportShoes.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _usersManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolesManager;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) //, RoleManager<IdentityRole> rolesManager)
        {
            this._signInManager = signInManager;
            this._usersManager = userManager;
            //this._rolesManager = rolesManager;
        }
        public IActionResult Register()
        {
            //var model = new UserModel();

            // Lấy danh sách các role từ IdentityRole
            //var roles = _rolesManager.Roles.Select(role => role.Name).ToList();

            //// Tạo SelectListItem cho mỗi role
            //model.RoleList = roles.Select(role => new SelectListItem
            //{
            //    Text = role,
            //    Value = role
            //});


            //return View(model);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel user)
        {
            //         var roles = _rolesManager.Roles.Select(role => role.Name).ToList();

            //         // Tạo SelectListItem cho mỗi role
            //         user.RoleList = roles.Select(role => new SelectListItem
            //         {
            //             Text = role,
            //             Value = role,
            //	Selected = role.Equals("customer", StringComparison.OrdinalIgnoreCase)
            //});
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser { UserName = user.UserName, Name = user.Name, Email = user.Email, PhoneNumber = user.PhoneNumber, Address = user.Address, City = user.City, Ward = user.Ward, District = user.District };
                var result = await _usersManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    ViewBag.Notice = "Đăng kí thành công!";
                    // await _usersManager.AddToRoleAsync(newUser, user.Role);
                    await _usersManager.AddToRoleAsync(newUser, "customer");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
        public IActionResult Login(string returnUrl)
        {

            return View(new LoginVM { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = await _usersManager.FindByNameAsync(loginVM.UserName);
                    if (check == null)
                    {
                        ModelState.AddModelError("", "Không tồn tại tên tài khoản này!");
                        return View(loginVM);
                    }
                    if (await _usersManager.CheckPasswordAsync(check, loginVM.Password) == false)
                    {
                        ModelState.AddModelError("", "Sai thông tin đăng nhập!");
                        return View(loginVM);
                    }
                    var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, lockoutOnFailure: false);
                    //if (result.Succeeded)
                    //{
                    //    //return RedirectToAction("Index", "Home");
                    //    return Redirect(loginVM.ReturnUrl ?? "/");
                    //}
                    // After successful login, check user role and redirect accordingly
                    if (await _usersManager.IsInRoleAsync(check, "admin"))
                    {
                        return RedirectToAction("Index", "AdminHome", new { area = "admin" }); // Redirect to admin area
                    }
                    else
                    {
                        // Redirect to user's default page (e.g., Home)
                        return Redirect(loginVM.ReturnUrl ?? "/");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(loginVM);

        }
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            //return RedirectToAction("Login", "Account");
            return Redirect(returnUrl);
        }
    }
}
