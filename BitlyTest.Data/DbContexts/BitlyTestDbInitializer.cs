using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.DbContexts
{
	class BitlyTestDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BitlyTestDbContext>
	{
		protected override void Seed(BitlyTestDbContext context)
		{
			var links = new List<Link>()
			{
				new Link() {Created = DateTime.Now, OriginalUrl = "http://mail.ru", ShortUrl = "saf23rd"}
			};
			links.ForEach(s => context.Links.Add(s));
			context.SaveChanges();
			base.Seed(context);
		}
	}
}
