using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Data.Repositories
{
	public interface IVisitLogRepository
	{
		VisitLog Add(VisitLog log);
	}
}
