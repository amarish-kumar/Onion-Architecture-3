using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdamS.OnlineStore.Startup))]
namespace AdamS.OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
