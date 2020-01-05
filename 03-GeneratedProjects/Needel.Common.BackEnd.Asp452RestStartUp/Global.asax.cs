using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Needel.Common.BackEnd.Asp452RestStartUp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CommonRepositoryLayer.IocRegistry();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
