using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitlyTest.Data.Models
{
	public class Link
	{
		public int Id { get; set; }
		[MaxLength(2083)]
		public string OriginalUrl { get; set; }
		[MaxLength(32)]
		public string ShortUrl { get; set; }
		public DateTime Created { get; set; }

		public virtual ICollection<VisitLog> VisitLogs { get; set; }
	}
}
