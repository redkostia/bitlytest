using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Bll.Extensions;
using BitlyTest.Bll.ViewModels;
using BitlyTest.Data.Models;
using BitlyTest.Data.Repositories;

namespace BitlyTest.Bll.Services
{
    public class BitlyService : IBitlyService
    {
	    private readonly IVisitLogRepository _visitLogRepository;
	    private readonly ILinkRepository _linkRepository;
	    public BitlyService(IVisitLogRepository visitLogRepository, ILinkRepository linkRepository)
	    {
		    _visitLogRepository = visitLogRepository;
		    _linkRepository = linkRepository;
	    }

	    public string Add(string originalUrl)
	    {
		    var link = _linkRepository.GetLinkByOriginalUrl(originalUrl);
		    if (link != null)
		    {
			    return link.ShortUrl;
		    }

		    var shortUrl = originalUrl.GetMd5Hash();

		    link = new Link() {Created = DateTime.Now, OriginalUrl = originalUrl, ShortUrl = shortUrl};
		    link = _linkRepository.Save(link);
		    return link.ShortUrl;
	    }

	    public IEnumerable<LinkViewModel> GetLinks()
	    {
			return _linkRepository.Get().ToList().Select(c=> new LinkViewModel(c));
	    }

	    public string LogVisit(string shortUrl)
	    {
		    var link = _linkRepository.GetLinkByShortUrl(shortUrl);
		    if (link == null)
		    {
				return null;
		    }

		    _visitLogRepository.Add(new VisitLog() {Created = DateTime.Now, LinkId = link.Id});
		    return link.OriginalUrl;
	    }
    }
}
