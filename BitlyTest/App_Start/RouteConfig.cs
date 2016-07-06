using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BitlyTest
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
				name: "Link",
				url: "{url}",
				defaults: new { controller = "Home", action = "Index" }
			);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{url}",
				defaults: new { controller = "Home", action = "Index", url = UrlParameter.Optional }
			);
		}
	}
}
