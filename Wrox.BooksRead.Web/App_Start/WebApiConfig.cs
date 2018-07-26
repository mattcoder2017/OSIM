using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Wrox.BooksRead.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "ExtendedApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            //config.Routes.MapHttpRoute(
            //    name: "SubscribeApi",
            //    routeTemplate: "api/Product/Subscribe/{id}",
            //    defaults: new { controller = "ProductController",  id=RouteParameter.Optional }
            //);
        }
    }
}
