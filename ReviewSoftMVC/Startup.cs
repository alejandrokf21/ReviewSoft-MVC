using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewSoftMVC.Startup))]
namespace ReviewSoftMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
