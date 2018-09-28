using System.Web;
using System.Web.Http;
using Project.APi.Configs;

namespace Project.APi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Initialize();
        }
    }
}