using System.Linq;
using System.Web.Http;

namespace Project.APi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            System.Net.Http.Headers.MediaTypeHeaderValue app = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(x => x.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(app);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}