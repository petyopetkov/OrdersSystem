using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrdersSystem.Web.Startup))]

namespace OrdersSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
