using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoursquareBrno.Startup))]
namespace FoursquareBrno
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
        }
    }
}
