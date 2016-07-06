using System.Collections.Generic;
using BitlyTest.Bll.ViewModels;

namespace BitlyTest.Bll.Services
{
	public interface IBitlyService
	{
		string Add(string originalUrl);
		IEnumerable<LinkViewModel> GetLinks(int pageSize, int pageNo);
		string LogVisit(string shortUrl);
	}
}