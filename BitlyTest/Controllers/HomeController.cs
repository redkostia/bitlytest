using System.Web.Mvc;
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
		//public ActionResult Index()
		//{
		//	ViewBag.Title = "Home Page";
			
		//	//ViewBag.Links = links;
			
		//}

		public ActionResult Index(string url = null)
		{
			//_bitlyService.Add("http://ya.ru");
			var originalUrl = _bitlyService.LogVisit(url);
			if (string.IsNullOrEmpty(originalUrl))
			{
				return View();
			}
			return Redirect(originalUrl);
		}
	}
}
