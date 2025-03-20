using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryMS.Startup))]
namespace LibraryMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
