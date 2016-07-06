using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.DbContexts
{
	public interface IBitlyTestDbContext
	{
		 DbSet<VisitLog> VisitLogs { get; set; }
		 DbSet<Link> Links { get; set; }
		void SaveChanges();
	}
}
