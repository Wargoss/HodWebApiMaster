using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HodApiFront.Startup))]
namespace HodApiFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
