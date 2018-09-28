using Project.APi.Configs;
using System.Web.Http;

namespace Project.APi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Initialize();
        }
    }
}