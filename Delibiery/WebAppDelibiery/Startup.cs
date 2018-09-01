using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppDelibiery.Startup))]
namespace WebAppDelibiery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
