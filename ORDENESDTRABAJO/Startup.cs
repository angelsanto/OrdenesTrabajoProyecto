using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ORDENESDTRABAJO.Startup))]
namespace ORDENESDTRABAJO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
