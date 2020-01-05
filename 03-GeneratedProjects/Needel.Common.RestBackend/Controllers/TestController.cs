using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Needel.Common.RestBackend.Controllers
{
    public class TestController : ApiController
    {
        string Get()
        {
            return "Hello Wordl!";
        }
    }
}
