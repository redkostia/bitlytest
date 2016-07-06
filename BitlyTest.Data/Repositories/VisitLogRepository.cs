using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.DbContexts;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.Repositories
{
	public class VisitLogRepository : IVisitLogRepository
	{
		private readonly IBitlyTestDbContext _dbContext;

		public VisitLogRepository(IBitlyTestDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public VisitLog Add(VisitLog log)
		{
			_dbContext.VisitLogs.Add(log);
			_dbContext.SaveChanges();
			return log;
		}
	}
}
