using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032AssignmentProject.Startup))]
namespace FIT5032AssignmentProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
