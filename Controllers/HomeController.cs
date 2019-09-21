using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Livescores.Models;
using System.Net;
using Newtonsoft.Json;
using Livescores.Services;

namespace Livescores.Controllers
{
	public class HomeController : Controller
	{
		IApiService apiService;
		public HomeController(IApiService apiService)
		{
			this.apiService = apiService;
		}

		public IActionResult Index()
		{
			return View(apiService.GetFixtures());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
