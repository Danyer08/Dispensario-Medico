using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DispensarioMedicoUnapec.Startup))]
namespace DispensarioMedicoUnapec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
