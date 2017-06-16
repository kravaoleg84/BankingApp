using BankingApp.WEB.AutoMapperClass;
using System.Web.Http;

namespace BankingApp.WEB
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
