using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Instaclone.Startup))]
namespace Instaclone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
