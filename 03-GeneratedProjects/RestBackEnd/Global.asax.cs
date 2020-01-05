using Needel.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RestBackEnd
{
    public partial class WebApiApplication : System.Web.HttpApplication
    {
        public SetupNeedelAppSettings NeeddelAppSettings;

        protected void Application_Start()
        {
            NeeddelAppSettings = new SetupNeedelAppSettings();
            //NeeddelAppSettings.ReadBasicPropertiesFromConfig();
            //NeeddelAppSettings.LoadDatabaseProperties();

            Needel.Common.Application.CommonRepositoryLayer.IocRegistry();
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
