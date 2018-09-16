using System;
using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace OSIM.IdentityServer2
{
    internal class Scopes
    {
        internal static IEnumerable<Scope> Get()
        {
            return new[]
            {
               StandardScopes.OpenId,
               StandardScopes.Address,
               StandardScopes.ProfileAlwaysInclude,  //always include claims in token
               //new Scope() {
               //    Name ="OSIM-Manage",
               //    DisplayName ="OSIM Management",
               //    Type = ScopeType.Resource  },
               new Scope()
               {
                   Name = "roles",
                   Type = ScopeType.Identity,
                   DisplayName = "My Custom Roles",
                   Claims = new List<ScopeClaim>
                   {  new ScopeClaim ("role", true)
                   }
               }
           };
        }
    }
}