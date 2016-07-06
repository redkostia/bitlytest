using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitlyTest.Data.Models
{
	public class Link
	{
		public int Id { get; set; }
		public string OriginalUrl { get; set; }
		public string ShortUrl { get; set; }
		public DateTime Created { get; set; }

		public virtual ICollection<VisitLog> VisitLogs { get; set; }
	}
}
