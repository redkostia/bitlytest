using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.DbContexts
{
	public class BitlyTestDbContext : DbContext, IBitlyTestDbContext
	{
		public BitlyTestDbContext() : base("DefaultConnection")
		{
			
		}

		public DbSet<VisitLog> VisitLogs { get; set; }
		public DbSet<Link> Links { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		public new void SaveChanges()
		{
			base.SaveChanges();
		}
	}
}
