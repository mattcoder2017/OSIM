using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Microsoft.Owin.Security.OpenIdConnect;
using OSIM.fields;
using System.Web.Helpers;
using Microsoft;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(OSIM.Web.Startup))]
namespace OSIM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            //  GlobalConfiguration.Configuration.DependencyResolver = new Unity.UnityDependencyResolver(unity);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityModel.JwtClaimTypes.Name;

            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = "Cookies" });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = Fields.HybridClientId,
                    Authority = Fields.STS,
                    RedirectUri = Fields.CallBack,
                    SignInAsAuthenticationType = "Cookies",
                    ResponseType = "code id_token token",
                    //Scope = "openid profile address",
                    Scope = "openid",

                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        //SecurityTokenValidated = async n=>
                        //{
                        //    TokenHelper.DecodeAndWrite(n.ProtocolMessage.IdToken);
                        //    TokenHelper.DecodeAndWrite(n.ProtocolMessage.AccessToken);

                        //    var givenNameClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.GivenName);
                        //    var familyNameClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.FamilyName);
                        //    //var addressClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Address);
                        //    var subjectClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Subject);

                        //    var nameClaim = new System.Security.Claims.Claim(IdentityModel.JwtClaimTypes.Name, Fields.STS + subjectClaim.Value);

                        //    //Create a customer ClaimIdentity which is container of received claimns
                        //    var nameClaimsIdentity = new ClaimsIdentity(
                        //        n.AuthenticationTicket.Identity.AuthenticationType,
                        //        IdentityModel.JwtClaimTypes.Name,
                        //        IdentityModel.JwtClaimTypes.Role
                        //               );

                        //    nameClaimsIdentity.AddClaim(givenNameClaim);
                        //    nameClaimsIdentity.AddClaim(familyNameClaim);
                        //    //nameClaimsIdentity.AddClaim(addressClaim);
                        //    nameClaimsIdentity.AddClaim(nameClaim);
                        //    nameClaimsIdentity.AddClaim(new System.Security.Claims.Claim("access_token", n.ProtocolMessage.AccessToken));

                        //    n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(nameClaimsIdentity, n.AuthenticationTicket.Properties);

                        //}
                    }

                }

                );


            // ConfigureAuth(app);
        }

       

    }
}
