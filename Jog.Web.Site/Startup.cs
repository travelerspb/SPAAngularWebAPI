using System.Web;
using Jog.Web.Site;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Jog.Web.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}