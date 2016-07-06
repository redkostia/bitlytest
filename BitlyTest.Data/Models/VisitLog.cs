using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitlyTest.Data.Models
{
	public class VisitLog
	{
		public int Id { get; set; }
		public int LinkId { get; set; }
		public DateTime Created { get; set; }
	}
}
