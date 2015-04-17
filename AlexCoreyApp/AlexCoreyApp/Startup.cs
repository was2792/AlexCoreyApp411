using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlexCoreyApp.Startup))]
namespace AlexCoreyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
