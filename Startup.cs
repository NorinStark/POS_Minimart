using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS_Minimart.Startup))]
namespace POS_Minimart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
