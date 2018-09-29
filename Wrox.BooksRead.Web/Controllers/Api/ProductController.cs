using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Wrox.BooksRead.Web.DTO;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;
using Wrox.BooksRead.Web.Repository;
using Microsoft.AspNet.Identity;

namespace Wrox.BooksRead.Web.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IUnitOfWork uow;
        public ProductController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        //[HttpGet]
        [System.Web.Http.Route("get")]
        public IEnumerable<ProductDto> Get()
        {
            Mapper.CreateMap<Product, ProductDto>();
            var Products = UnitOfWork.ProductRepo.AllProduct();
            return Products.Select(Mapper.Map<Product, ProductDto>);

        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            try
            {
                uow.ProductRepo.Delete(Id);
                uow.Complete();
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return BadRequest("The product no longer exist!!");
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
