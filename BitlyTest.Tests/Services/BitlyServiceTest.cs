using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitlyTest.Bll.Extensions;
using BitlyTest.Bll.Services;
using BitlyTest.Data.DbContexts;
using BitlyTest.Data.Models;
using BitlyTest.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BitlyTest.Tests.Services
{
	[TestClass]
	public class BitlyServiceTest
	{
		[TestMethod]
		public void Add_Url_Test()
		{
			var data = new List<Link>().AsQueryable();

			var mockLink = new Mock<DbSet<Link>>();
			var mockLog = new Mock<DbSet<VisitLog>>();
			var mockContext = new Mock<FakeDbContext>();

			mockContext.Setup(m => m.Links).Returns(mockLink.Object);
			mockContext.Setup(m => m.VisitLogs).Returns(mockLog.Object);
			mockContext.Setup(m => m.Set<Link>()).Returns(mockLink.Object);

			mockLink.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(data.Provider);
			mockLink.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(data.Expression);
			mockLink.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockLink.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

			ILinkRepository linkRepo = new LinkRepository(mockContext.Object);
			IVisitLogRepository visitLogRepository = new VisitLogRepository(mockContext.Object);

			var service = new BitlyService(visitLogRepository: visitLogRepository, linkRepository: linkRepo);

			const string firstString = "http://mail.ru";
			var firstShortUrl = service.Add(firstString);
			Assert.IsNotNull(firstShortUrl);
			mockLink.Verify(m => m.Add(It.IsAny<Link>()), Times.Once());

			var secondShortUrl = service.Add(firstString);
			Assert.IsNotNull(secondShortUrl);
			Assert.AreEqual(firstShortUrl, secondShortUrl);

		}

		[TestMethod]
		public void Get_Links_And_Log_Visit_Test()
		{
			var firstOriginalUrl = "http://mail.ru";
			var secondOriginalUrl = "http://yandex.ru";
			var firstShortUrl = firstOriginalUrl.GetMd5Hash();
			var secondShortUrl = secondOriginalUrl.GetMd5Hash();
			var links =
				new List<Link>()
				{
					new Link()
					{
						Created = DateTime.Now,
						Id = 1,
						OriginalUrl = firstOriginalUrl,
						ShortUrl = firstShortUrl,
						VisitLogs =  new List<VisitLog>()
						{
							new VisitLog() {Created = DateTime.Now, LinkId = 1, Id = 1},
							new VisitLog() {Created = DateTime.Now, LinkId = 1, Id = 2}
						}
					},
					new Link()
					{
						Created = DateTime.Now,
						Id = 2,
						OriginalUrl = secondOriginalUrl,
						ShortUrl = secondShortUrl,
						VisitLogs = new List<VisitLog>()
					}
				}.AsQueryable();

			var logs = new List<VisitLog>()
			{
				new VisitLog() {Created = DateTime.Now, LinkId = 1, Id = 1},
				new VisitLog() {Created = DateTime.Now, LinkId = 1, Id = 2}
			}.AsQueryable();

			var mockLink = new Mock<DbSet<Link>>();
			var mockLog = new Mock<DbSet<VisitLog>>();

			var mockContext = new Mock<FakeDbContext>();
			mockContext.Setup(m => m.Links).Returns(mockLink.Object);
			mockContext.Setup(m => m.VisitLogs).Returns(mockLog.Object);
			mockContext.Setup(m => m.Set<Link>()).Returns(mockLink.Object);
			mockContext.Setup(m => m.Set<VisitLog>()).Returns(mockLog.Object);
			ILinkRepository linkRepo = new LinkRepository(mockContext.Object);
			IVisitLogRepository visitLogRepository = new VisitLogRepository(mockContext.Object);

			var service = new BitlyService(visitLogRepository: visitLogRepository, linkRepository:linkRepo);

			mockLink.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(links.Provider);
			mockLink.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(links.Expression);
			mockLink.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(links.ElementType);
			mockLink.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(() => links.GetEnumerator());

			mockLog.As<IQueryable<VisitLog>>().Setup(m => m.Provider).Returns(logs.Provider);
			mockLog.As<IQueryable<VisitLog>>().Setup(m => m.Expression).Returns(logs.Expression);
			mockLog.As<IQueryable<VisitLog>>().Setup(m => m.ElementType).Returns(logs.ElementType);
			mockLog.As<IQueryable<VisitLog>>().Setup(m => m.GetEnumerator()).Returns(() => logs.GetEnumerator());

			var result = service.GetLinks(pageSize:10,pageNo: 0).ToList();

			Assert.AreEqual(2, result.Count);

			var originalUrl = service.LogVisit(firstShortUrl);
			Assert.AreEqual(originalUrl, firstOriginalUrl);
			mockLog.Verify(m => m.Add(It.IsAny<VisitLog>()), Times.Once());
		}
	}
}
