using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataSourseControl.Startup))]
namespace DataSourseControl
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
