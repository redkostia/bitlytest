using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Data.Models;

namespace BitlyTest.Bll.ViewModels
{
	[DataContract]
	public class LinkViewModel
	{
		[DataMember]
		public string OriginalUrl { get; set; }
		[DataMember]
		public string ShortUrl { get; set; }
		[DataMember]
		public DateTime Created { get; set; }
		[DataMember]
		public int VisitCount { get; set; }
		[DataMember]
		public string DateFormatted { get { return Created.ToString("f"); } }

		public LinkViewModel(Link link)
		{
			this.OriginalUrl = link.OriginalUrl;
			this.ShortUrl = link.ShortUrl;
			this.Created = link.Created;
			this.VisitCount = link.VisitLogs != null ?  link.VisitLogs.Count : 0;
		}
	}
}
