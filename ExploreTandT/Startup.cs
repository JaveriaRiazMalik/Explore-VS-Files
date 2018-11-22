using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExploreTandT.Startup))]
namespace ExploreTandT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
