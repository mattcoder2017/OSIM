using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;
using System.Threading.Tasks;
using OSIM.fields;

namespace Wrox.BooksRead.Web.Common
{
    public static class Utility
    {
        public const String PRODUCT_PRICE_CHANGE_NOTIFICATION = "Product Price changed, Product Id : {0} Product Name : {1} Orginal Price : {2}, New Pricce : {3} ";
    }

    public static class TokenHelper
    {
        public static void DecodeAndWrite(string token)
        {
            try
            {
                var parts = token.Split('.');

                string partToConvert = parts[1];
                partToConvert = partToConvert.Replace('-', '+');
                partToConvert = partToConvert.Replace('_', '/');
                switch (partToConvert.Length % 4)
                {
                    case 0:
                        break;
                    case 2:
                        partToConvert += "==";
                        break;
                    case 3:
                        partToConvert += "=";
                        break;
                    default:
                        break;
                }

                var partAsBytes = Convert.FromBase64String(partToConvert);
                var partAsUTF8String = Encoding.UTF8.GetString(partAsBytes, 0, partAsBytes.Count());

                // Json .NET
                var jwt = JObject.Parse(partAsUTF8String);

                // Write to output
                Debug.Write(jwt.ToString());
            }
            catch (Exception ex)
            {
                // something went wrong
                Debug.Write(ex.Message);
            }
        }
    }

    public class AppResourceAuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
                {
                case Fields.WroxBooksRead:
                    return CheckRole(context);
                default:
                    return Nok();
              }}

        public Task<bool> CheckRole(ResourceAuthorizationContext context)
        {
            if (context.Action.First().Value == Fields.Read)
                return Eval(context.Principal.HasClaim("role", Fields.RoleUser));
            if (context.Action.First().Value == Fields.Write)
                return Eval(context.Principal.HasClaim("role", Fields.RoleAdmin));
            return Nok();
        }
    }
}