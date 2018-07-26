using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Wrox.BooksRead.Web.DTO;
using Wrox.BooksRead.Web.Extensions;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;

namespace Wrox.BooksRead.Web.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/ProductSubscription")]
    public class ProductSubscriptionController : ApiController
    {
        
        public ProductSubscriptionController()
        {
        }

        [System.Web.Http.Route("get")]
        public IEnumerable<ProductDto> Get()
        {
            Mapper.CreateMap<Product, ProductDto>();
            var Products = UnitOfWork.ProductRepo.AllProduct();
            return Products.Select(Mapper.Map<Product, ProductDto>);

        }

        //[System.Web.Http.Route("Subscribe")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Subscribe(int id)
        {
            try
            {

                Product product = UnitOfWork.ProductRepo.GetProductByIdWithUpdate(id);
                if (product.ProductSubscriptions.Where(e => e.ProductId == id
                 && e.AspNetUser.Id == User.Identity.GetUserId()).Count() == 0)
                {
                    EFDBEntities DBContext = new EFDBEntities();
                    Product p = DBContext.Products
                 .Where(i => i.Id == id)
                 .Include(i => i.ProductSubscriptions)
                 .FirstOrDefault<Product>();
                     

                    p.ProductSubscriptions.Add(new ProductSubscription { ProductId = p.Id, UserId = "a60d758a-684b-4228-9744-8df530c49efc" });
                    DBContext.SaveChanges();
                    //product.ProductSubscriptions.Add(new ProductSubscription
                    //{ Product = product,  ProductId = int.Parse(id), UserId = User.Identity.GetUserId() });
                    
                    //UnitOfWork.Complete();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            { }
        }

        private IUnitOfWork UnitOfWork
        {
            get { return DependencyResolver.Current.GetService<IUnitOfWork>(); }

        }
    }
}
