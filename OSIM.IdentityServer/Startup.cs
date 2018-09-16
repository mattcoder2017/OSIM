using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;

[assembly: OwinStartupAttribute(typeof(OSIM.IdentityServer.Startup))]
namespace OSIM.IdentityServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
            app.Map("/identity", idsSvrWeb =>
            {
                var corsSvr = new DefaultCorsPolicyService()
                { AllowAll = true };



                //var options = new IdentityServerOptions
                //{
                //    Factory = 
                //};
                //idsSvrWeb.UseIdentityServer(options);
            }



          );
        }
    }
}
