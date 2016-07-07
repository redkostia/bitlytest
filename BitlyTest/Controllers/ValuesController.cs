using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BitlyTest.Bll.Services;
using BitlyTest.Bll.ViewModels;

namespace BitlyTest.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly IBitlyService _bitlyService;

		public ValuesController(IBitlyService bitlyService)
		{
			_bitlyService = bitlyService;
		}
		// GET api/values
		public IEnumerable<LinkViewModel> Get()
		{
			return _bitlyService.GetLinks();
		}

		[HttpPost]
		public string Post([FromBody]string originalUrl)
		{
			return _bitlyService.Add(originalUrl);
		}

		//// POST api/values
		//[HttpPost]
		//public string Post([FromBody]PostData data)
		//{
		//	return _bitlyService.Add(data.OriginalUrl);
		//}

		public class PostData
		{
			public string OriginalUrl { get; set; }
		}
	}
}
