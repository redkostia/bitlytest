using System.Data.Entity;
using System.Linq;
using BitlyTest.Data.DbContexts;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.Repositories
{
	public class LinkRepository : ILinkRepository
	{
		private readonly IBitlyTestDbContext _dbContext;

		public LinkRepository(IBitlyTestDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Link Save(Link link)
		{
			_dbContext.Links.Add(link);
			_dbContext.SaveChanges();
			return link;
		}

		public IQueryable<Link> Get()
		{
			return _dbContext.Links.OrderByDescending(c => c.Created);
		}

		public Link GetLinkByShortUrl(string shrinkUrl)
		{
			return _dbContext.Links.FirstOrDefault(c => c.ShortUrl == shrinkUrl);
		}


		public Link GetLinkByOriginalUrl(string originalUrl)
		{
			return _dbContext.Links.FirstOrDefault(c => c.OriginalUrl == originalUrl);
		}
	}
}
