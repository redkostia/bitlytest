using System.Web.Mvc;
using System.Web.Routing;
using BitlyTest.Bll.Services;

namespace BitlyTest.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBitlyService _bitlyService;

		public HomeController(IBitlyService bitlyService)
		{
			_bitlyService = bitlyService;
		}

		public ActionResult Index(string url = null)
		{
			if (string.IsNullOrEmpty(url))
			{
				return View();
			}
			var originalUrl = _bitlyService.LogVisit(url);
			if (string.IsNullOrEmpty(originalUrl))
			{
				return Redirect("/");
			}
			return Redirect(originalUrl);
		}
	}
}
