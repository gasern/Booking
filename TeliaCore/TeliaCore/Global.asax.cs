using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using TeliaCore.Infrastructure;

namespace TeliaCore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });


            routes.MapRoute(
            "AccountLogin", // Route name
            "{controller}/{action}", // URL with parameters
            new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
        );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        readonly WindsorContainer applicationWideWindsorContainer = new WindsorContainer();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(applicationWideWindsorContainer));

            // Initialize / install components in container
            applicationWideWindsorContainer.Install(new WindsorInstaller());
        }

        protected void Application_Error(Object sender, System.EventArgs e)
        {
            System.Web.HttpContext context = HttpContext.Current;
            System.Exception ex = Context.Server.GetLastError();

            context.Server.ClearError();

            //Response.Redirect("error");

        }
    }
}