using System;
using System.Collections.Generic;
using IdentityServer3.Core.Services.InMemory;
using System.Security.Claims;
using OSIM.fields;
using IdentityServer3.Core;

namespace OSIM.IdentityServer2
{
    internal class Users
    {
        internal static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser {
                    Username = "Mattcoder",
                    Password ="1",
                    Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf",
                    Claims = new[]{
                        new Claim (Constants.ClaimTypes.GivenName, "Matt" ),
                        new Claim (Constants.ClaimTypes.FamilyName, "Yang" ),
                        new Claim (Constants.ClaimTypes.Address, "401, 81, JiLiXia RD North, Guangzhou" ),
                        new Claim (Constants.ClaimTypes.Role, Fields.RoleUser),
                        new Claim (Constants.ClaimTypes.Role, Fields.RoleAdmin)
                    }
                }
                //,

                 //new InMemoryUser {
                 //   Username = "Simon",
                 //   Password ="1",
                 //   Subject = "b05d3546-6ca8-4d32-b95c-77e94d705ddf",
                 //   Claims = new[]{
                 //       new Claim (Constants.ClaimTypes.GivenName, "Simon" ),
                 //       new Claim (Constants.ClaimTypes.FamilyName, "Yang" ),
                 //       new Claim (Constants.ClaimTypes.Address, "401, 81, JiLiXia RD North, Guangzhou" ),
                 //       new Claim (Constants.ClaimTypes.Role, Fields.WebResource)
                 //       //new Claim (Constants.ClaimTypes.Role, Fields.WroxBooksRead)
                 //   }
                //}
            };
            
        }
    }
}