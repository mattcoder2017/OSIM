using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Wrox.BooksRead.Web.Common
{
    public static class Utility
    {
        public const String PRODUCT_PRICE_CHANGE_NOTIFICATION = "Product Price changed, Product Id : {0} Product Name : {1} Orginal Price : {2}, New Pricce : {3} ";
        public static IPAddress[] GetIPAddresses()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            return ipHostInfo.AddressList;
        }
    }

    
}