using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GUI_eksamen___Opgave_2.Startup))]
namespace GUI_eksamen___Opgave_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
