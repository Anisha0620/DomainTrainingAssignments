using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CFDB_practice.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		// Constructor with ILogger for logging
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		// Index action
		public IActionResult Index()
		{
			return View();
		}

		// Privacy action
		public IActionResult Privacy()
		{
			return View();
		}

		// Error action with ResponseCache attribute
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}


