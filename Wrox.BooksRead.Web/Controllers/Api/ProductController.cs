using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wrox.BooksRead.Web.Repository;

namespace Wrox.BooksRead.Web.Controllers.Api
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IProductRepository ProdRepo;
        public ProductController(IProductRepository prodRepo)
        {
            ProdRepo = prodRepo;
        }
        public ProductController()
        {
        }
        //[HttpGet]
        [Route("get")]
        public IEnumerable<string> Get()
        {
            return new String[] { "one", "two" };
        }
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                ProdRepo.Delete(Id);
                return Ok();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            { }
        }

    }
}
