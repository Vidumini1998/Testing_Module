using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMSWebApplication.Startup))]
namespace PMSWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
