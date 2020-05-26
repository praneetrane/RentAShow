using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentAShow.Startup))]
namespace RentAShow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
