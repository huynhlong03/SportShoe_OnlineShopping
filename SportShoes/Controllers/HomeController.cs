using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportShoes.Models;
using System.Diagnostics;

namespace SportShoes.Controllers
{
	[AllowAnonymous]
	//[Authorize(Roles = "Customer")]
  
	public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
