using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilanWeb.Startup))]
namespace FilanWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
