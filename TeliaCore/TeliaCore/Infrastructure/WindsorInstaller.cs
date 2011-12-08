using System.Web.Mvc;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web;
using TeliaCore.Controllers;
using TeliaCore.Services;
using TeliaCore.Services.Interfaces;

namespace TeliaCore.Infrastructure
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			// Register all controllers from this assembly
            container.Register(AllTypes.FromThisAssembly()
                                .BasedOn<IController>()
                                .If(Component.IsInSameNamespaceAs<HomeController>())
                                .If(t => t.Name.EndsWith("Controller"))
                                .Configure(c => c.LifeStyle.Transient));


			// Register HttpContext(Base) and HttpRequest(Base) so it automagically can be injected using IoC
			container.AddFacility<FactorySupportFacility>();
			container.Register(Component.For<HttpRequestBase>().LifeStyle.PerWebRequest
					 .UsingFactoryMethod(() => new HttpRequestWrapper(HttpContext.Current.Request)));
			container.Register(Component.For<HttpContextBase>().LifeStyle.PerWebRequest
					.UsingFactoryMethod(() => new HttpContextWrapper(HttpContext.Current)));

			// Respository and Service registrations
			container.Register(Component.For<IBookingService>().ImplementedBy<BookingService>().LifeStyle.Singleton);
            container.Register(Component.For<IContactService>().ImplementedBy<ContactService>().LifeStyle.Singleton);
            container.Register(Component.For<IAdminService>().ImplementedBy<AdminService>().LifeStyle.Singleton); 
            
            container.Register(Component.For<ISessionValidator>().ImplementedBy<SessionValidator>().LifeStyle.Singleton);
		}
	}
}