using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SourceControlAssignment1.Startup))]
namespace SourceControlAssignment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
