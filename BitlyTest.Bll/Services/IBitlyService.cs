using System.Collections.Generic;
using BitlyTest.Bll.ViewModels;

namespace BitlyTest.Bll.Services
{
	public interface IBitlyService
	{
		string Add(string originalUrl);
		IEnumerable<LinkViewModel> GetLinks();
		string LogVisit(string shortUrl);
	}
}