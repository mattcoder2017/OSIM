using System;
using Microsoft;
using Microsoft.Owin;
using Owin;
using Unity;
using Wrox.BooksRead.Web.Repository;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Controllers;
using Unity.AspNet.Mvc;
using System.Reflection;
using System.Linq;
using Unity.RegistrationByConvention;
using Unity.Injection;
using System.Web.Http;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Web.Helpers;
using Microsoft.Owin.Security.OpenIdConnect;
using OSIM.fields;
using Wrox.BooksRead.Web.Common;
using System.IdentityModel.Claims;
using System.Security.Claims;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Wrox.BooksRead.Web.Startup))]
namespace Wrox.BooksRead.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var unity = CreateUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(unity));
      
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityModel.JwtClaimTypes.Name;
           
            //Add the authorization handler class to your app.
            app.UseResourceAuthorization(new AppResourceAuthorizationManager());

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            { AuthenticationType = "Cookies" });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = Fields.HybridClientId,
                    Authority = Fields.STS,
                    RedirectUri = Fields.CallBack,
                    SignInAsAuthenticationType = "Cookies",
                    ResponseType = "id_token code token",
                    Scope = "openid profile roles",
                   // Scope = "openid",

                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        SecurityTokenValidated = async n =>
                        {
                            TokenHelper.DecodeAndWrite(n.ProtocolMessage.IdToken);
                            TokenHelper.DecodeAndWrite(n.ProtocolMessage.AccessToken);

                            var givenNameClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.GivenName);
                            var familyNameClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.FamilyName);
              //              var addressClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Address);
                            var subjectClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Subject);
                            var roleClaim = n.AuthenticationTicket.Identity.FindAll(IdentityModel.JwtClaimTypes.Role);

                            var nameClaim = new System.Security.Claims.Claim(IdentityModel.JwtClaimTypes.Name, Fields.STS + subjectClaim.Value);

                            //Create a customer ClaimIdentity which is container of received claimns
                            var nameClaimsIdentity = new ClaimsIdentity(
                                n.AuthenticationTicket.Identity.AuthenticationType,
                                IdentityModel.JwtClaimTypes.Name,
                                IdentityModel.JwtClaimTypes.Role
                                       );

                            nameClaimsIdentity.AddClaim(givenNameClaim);
                            nameClaimsIdentity.AddClaim(familyNameClaim);
                          //  nameClaimsIdentity.AddClaim(addressClaim);
                            nameClaimsIdentity.AddClaim(nameClaim);
                            nameClaimsIdentity.AddClaims(roleClaim);
                            nameClaimsIdentity.AddClaim(new System.Security.Claims.Claim("access_token", n.ProtocolMessage.AccessToken));

                            n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(nameClaimsIdentity, n.AuthenticationTicket.Properties);
                           
                        }
                    }                
                });
           // ConfigureAuth(app);
        }

        private IUnityContainer CreateUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
                 
            //container.RegisterType<Product>(new  InjectionProperty("ProductRepo"));

            return container;
        }

    }
}
