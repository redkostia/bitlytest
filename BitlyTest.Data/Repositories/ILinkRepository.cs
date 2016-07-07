using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.Repositories
{
	public interface ILinkRepository
	{
		Link Save(Link link);
		IQueryable<Link> Get();
		Link GetLinkByShortUrl(string shrinkUrl);
		Link GetLinkByOriginalUrl(string originalUrl);

	}
}
