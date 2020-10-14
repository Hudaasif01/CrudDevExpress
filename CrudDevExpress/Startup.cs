using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudDevExpress.Startup))]
namespace CrudDevExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
