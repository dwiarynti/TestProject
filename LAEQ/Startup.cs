using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAEQ.Startup))]
namespace LAEQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
