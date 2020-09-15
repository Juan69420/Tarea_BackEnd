using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tarea_BackEnd_MVC.Startup))]
namespace Tarea_BackEnd_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
