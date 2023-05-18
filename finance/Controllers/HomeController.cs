using ASPFinance.Application.Services;
using ASPFinance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPFinance.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly FinanceApplicationServices _services;

		public HomeController(ILogger<HomeController> logger, FinanceApplicationServices services)
		{
			_logger = logger;
			_services = services;
		}

		private void AddViewBags(DateTime? dataBegin, DateTime? dataEnd)
		{
			ViewBag.DataEnd = dataEnd ?? DateTime.Today;
			ViewBag.DataBegin = dataBegin ?? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
		}

		public async Task<IActionResult> Index(DateTime? dataBegin, DateTime? dataEnd)
		{
			AddViewBags(dataBegin, dataEnd);

			if (ViewBag.DataBegin > ViewBag.DataEnd)
			{
				ViewBag.DataBegin = ViewBag.DataEnd;
				AddViewBags(ViewBag.DataBegin, ViewBag.DataEnd);
			}

			return View(await _services.GetDailyBalances(ViewBag.DataBegin, ViewBag.DataEnd));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}