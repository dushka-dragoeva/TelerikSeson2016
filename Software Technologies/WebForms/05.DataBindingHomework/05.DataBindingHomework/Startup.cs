using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_05.DataBindingHomework.Startup))]
namespace _05.DataBindingHomework
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
