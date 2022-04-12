using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rebuild_Project.Startup))]
namespace Rebuild_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
