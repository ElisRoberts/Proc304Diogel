using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Digoel.Startup))]
namespace Digoel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
