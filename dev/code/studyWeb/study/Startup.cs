using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(study.Startup))]
namespace study
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
