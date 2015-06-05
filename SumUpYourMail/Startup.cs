using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumUpYourMail.Startup))]
namespace SumUpYourMail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
