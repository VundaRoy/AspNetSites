using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudWebSite.Startup))]
namespace CrudWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
