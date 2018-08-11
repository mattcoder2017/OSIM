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
        private IUnitOfWork uow ;
        public ProductSubscriptionController(IUnitOfWork uow)
        {
            this.uow = uow;
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
                     product.ProductSubscriptions.Add(new ProductSubscription
                    { Product = product, ProductId = id, UserId = User.Identity.GetUserId() });

                    UnitOfWork.Complete();
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
            get {
                return
                  this.uow;
                    //DependencyResolver.Current.GetService<IUnitOfWork>();
            }

        }
    }
}
