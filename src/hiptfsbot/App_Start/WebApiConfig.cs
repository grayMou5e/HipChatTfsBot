using System.Web.Http;

namespace hiptfsbot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "HipChatTfsBot",
                routeTemplate: "api/",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
