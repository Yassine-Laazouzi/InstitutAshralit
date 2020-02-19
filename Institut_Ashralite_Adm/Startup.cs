using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Institut_Ashralite_Adm.Startup))]
namespace Institut_Ashralite_Adm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
