namespace Project.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[]{"Project.Areas.Admin.Controllers"}
            );

            /*routes.MapRoute(
                name: "DefaultWithArea",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/
        }
    }
}
