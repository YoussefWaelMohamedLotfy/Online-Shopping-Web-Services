using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Online_Shopping_Service.Startup))]
namespace Online_Shopping_Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR("/Chat/Index", new HubConfiguration { EnableDetailedErrors = true });
        }
    }
}
