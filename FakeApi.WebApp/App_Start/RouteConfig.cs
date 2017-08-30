using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FakeApi.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            List<string> routeSystem = new List<string>() {
                "version"
            };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "dashboard/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ApiDefault",
                url: "api/{*permalink}",
                defaults: new { controller = "Api", action = "Permalink" }, 
                constraints: new { permalink = new ValidateCustomUrlConstraint(routeSystem) }
            );

            routes.MapRoute(
                name: "Version",
                url: "api/version",
                defaults: new { controller = "Api", action = "Version", slug = UrlParameter.Optional }
            );
        }
    }

    public class ValidateCustomUrlConstraint : IRouteConstraint
    {
        private readonly List<string> routeSystem;

        public ValidateCustomUrlConstraint(List<string> routeSystem)
        {
            this.routeSystem = routeSystem;
        }   
             
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[parameterName] != null)
            {
                var permalink = values[parameterName].ToString();
                if (routeSystem.Any(p => permalink.StartsWith(p)))
                    return false;
                else
                    return true;
                    
            }
            return false;
        }
    }
}
