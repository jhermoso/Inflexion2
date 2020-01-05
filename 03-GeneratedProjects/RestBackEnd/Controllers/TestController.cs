

namespace RestBackEnd.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// http://localhost:1964/Api/test/get
    /// </summary>
    /// <example>
    /// </example>
    [RoutePrefix("Test")]
    public class TestController : ApiController
    {
        public string Get()
        {




            return "Hello Wordl";
        }
    }
}
