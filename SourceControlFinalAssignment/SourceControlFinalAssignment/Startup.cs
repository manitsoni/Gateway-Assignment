using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SourceControlFinalAssignment.Startup))]
namespace SourceControlFinalAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
