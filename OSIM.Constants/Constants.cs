using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OSIM.fields
{
    public class Fields
    {
        public const String SiteName = "OSIM Identity";
        public const string AuthCodeClientId = "OSIMAuthCode";
        public const string AuthoCodeClientName = "OSIM Authorization Code";
        public const string Secret = "Secret";
        public const string CallBack = "https://localhost:44333/";
        public const string HybridClientId = "OSIMHybrid";
        public const string HybridClientName = "OSIM Hybrid";
        public const string STS= publicorigin + "/identity";
        public const string publicorigin = "https://localhost:44389";
        public const string WebResource = "WebResource";
        public const string WroxBooksRead = "WroxBooksRead";
        public const string Read = "read";
        public const string RoleUser = "user";
        public const string Write = "write";
        public const string RoleAdmin = "admin";
    }
}
