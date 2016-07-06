using System.Web.Http;
using System.Web.Mvc;
using BitlyTest.Bll.Services;
using BitlyTest.Data.DbContexts;
using BitlyTest.Data.Repositories;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace BitlyTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IBitlyService, BitlyService>();
			container.RegisterType<ILinkRepository, LinkRepository>();
			container.RegisterType<IVisitLogRepository, VisitLogRepository>();
	        container.RegisterType<IBitlyTestDbContext, BitlyTestDbContext>();
			//GlobalConfiguration.Configuration.DependencyResolver = new  UnityDependencyResolver(container);
			//DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

			GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
			
        }
    }
}