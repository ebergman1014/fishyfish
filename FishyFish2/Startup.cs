using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishyFish2.Startup))]
namespace FishyFish2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
