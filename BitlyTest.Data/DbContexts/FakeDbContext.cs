using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.DbContexts
{
	public class FakeDbContext : DbContext, IBitlyTestDbContext
	{
		public virtual DbSet<VisitLog> VisitLogs { get; set; }
		public virtual DbSet<Link> Links { get; set; }
		public new void SaveChanges()
		{
			base.SaveChanges();
		}
	}
}
