using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;
using OSIM.fields;
using Serilog;
using System.Security.Cryptography.X509Certificates;
using System;

[assembly: OwinStartupAttribute(typeof(OSIM.IdentityServer2.Startup))]
namespace OSIM.IdentityServer2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .CreateLogger();

            app.Map("/identity", idsSvrWeb =>
            {
                var corsSvr = new DefaultCorsPolicyService()
                { AllowAll = true };

                var idServerServiceFactory = new IdentityServerServiceFactory()
                   .UseInMemoryClients(Clients.Get()) //Declare the multiple flow that it supports. i.e. Open-Id, AuthCode etc
                   .UseInMemoryScopes(Scopes.Get())   //Declare scope that is support, i.e. user profile, custom scope for resource
                   .UseInMemoryUsers(Users.Get());    //User list

                idServerServiceFactory.CorsPolicyService = new Registration<IdentityServer3.Core.Services.ICorsPolicyService>(corsSvr);

                var options = new IdentityServerOptions
                {
                    SiteName = Fields.SiteName,
                    Factory = idServerServiceFactory,
                    SigningCertificate = LoadCertificate(),
                    IssuerUri = "http://xx/identity",
                    PublicOrigin = Fields.publicorigin
                };
                idsSvrWeb.UseIdentityServer(options);        //Declare this is IdentityServer
            }

          );
         
        }
        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\certificates\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
