using IdentityServer3.Core.Models;
using System.Collections.Generic;
using OSIM.fields;

namespace OSIM.IdentityServer2
{
    internal static class Clients
    {
        internal static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                     ClientId = Fields.AuthCodeClientId,
                     ClientName = Fields.AuthoCodeClientName,
                     Flow = Flows.AuthorizationCode,
                     AllowAccessToAllScopes = true,
                     RedirectUris = new List<string>()
                     {
                         Fields.CallBack
                     },
                     ClientSecrets = new List<Secret>()
                     {
                         new Secret (Fields.Secret.Sha256())
                     }

                },

                 new Client
                {
                     ClientId = Fields.HybridClientId,
                     ClientName = Fields.HybridClientName,
                     Flow = Flows.Hybrid,
                    // AllowAccessToAllScopes = true,
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "roles"
                        //"OSIM-Manage"
                    },

                    // redirect = URI of the MVC application
                    RedirectUris = new List<string>
                    {
                        Fields.CallBack
                    }
                }
            };

        }
    }
}