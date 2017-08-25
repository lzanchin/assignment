using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "LeftApi",
                //routeTemplate: "v1/{controller}/{id}/left",
                routeTemplate: "v1/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "RightApi",
            //    routeTemplate: "v1/{controller}/{id}/right",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
