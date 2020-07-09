using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartUniversity.Startup))]
namespace SmartUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
