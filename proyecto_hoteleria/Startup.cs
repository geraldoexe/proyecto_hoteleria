using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyecto_hoteleria.Startup))]
namespace proyecto_hoteleria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
