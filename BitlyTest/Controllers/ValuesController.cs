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
		public IEnumerable<LinkViewModel> Get(int pageSize = 10, int pageNo = 0)
		{
			return _bitlyService.GetLinks(pageSize: 10, pageNo: 0);
		}

	

		// POST api/values
		public string Post([FromBody]string originalUrl)
		{
			return _bitlyService.Add(originalUrl);
		}

	}
}
