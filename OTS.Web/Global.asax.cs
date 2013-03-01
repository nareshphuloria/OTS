using System.Web.Mvc;
using System.Web.Routing;
using OTS.CommonLayer.Mapper;
using OTS.CommonLayer.Unity;
using Microsoft.Practices.Unity;
using OTS.CommonLayer.UnityExtension;

namespace OTS.Web
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

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Initializes unity container and registers interface with service classes 
            OTSUnityContainerExtension.InitializeContainer();

            //Creates mapping between Data transfer objects and persistence layer
            OTSUnityContainer.Container.Resolve<IObjectMapper>().CreateMap();
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}