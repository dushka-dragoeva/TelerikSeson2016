using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebControlsAnd_HTMLControlsHomework.Startup))]
namespace WebControlsAnd_HTMLControlsHomework
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
