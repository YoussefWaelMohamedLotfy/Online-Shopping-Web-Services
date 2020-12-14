using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Shopping_Service.Startup))]
namespace Online_Shopping_Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
