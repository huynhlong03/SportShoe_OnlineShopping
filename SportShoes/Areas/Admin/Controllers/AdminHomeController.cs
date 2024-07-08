﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace SportShoes.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]


	public class AdminHomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
