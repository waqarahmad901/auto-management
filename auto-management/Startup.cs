using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(auto_management.Startup))]
namespace auto_management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
