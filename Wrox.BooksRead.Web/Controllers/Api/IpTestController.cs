using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wrox.BooksRead.Web.Common;

namespace Wrox.BooksRead.Web.Controllers.Api
{
    public class IpTestController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            String[] returnlist = new String[Utility.GetIPAddresses().Length];
           
            for (int i = 0; i< Utility.GetIPAddresses().Length; i++)
            {
                returnlist[i] = Utility.GetIPAddresses().ElementAt(i).ToString();
            }
            return returnlist;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}