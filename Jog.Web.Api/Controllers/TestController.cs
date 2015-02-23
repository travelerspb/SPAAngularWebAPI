using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jog.Web.Api.Controllers
{
    [RoutePrefix("")]
    public class TestController : ApiController
    {
        [Route("")]
        [HttpGet]
        public object Get()
        {
            return "Feel good";
        }
    }
}
