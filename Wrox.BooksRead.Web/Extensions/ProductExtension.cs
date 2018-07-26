using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;

namespace Wrox.BooksRead.Web.Extensions
{
    public static class ProductExtension
    {
        public static void AddCascadeUpdateToSubsription(this Product product, ProductSubscription subscription, IUnitOfWork uow)
        {
            
            product.ProductSubscriptions.Add(subscription);
            
            EFDBEntities ef = uow.DBAccess as EFDBEntities;
            ef.Set<ProductSubscription>().AsNoTracking();
            ef.Set<ProductSubscription>().Add(subscription);
            //ef.Entry(product).CurrentValues.SetValues(product);


            //ef.Entry(subscription).State = System.Data.Entity.EntityState.Added;
            //ef.Products.Add(product);
            //ef.ProductSubscriptions.Add(subscription);
        }
    }
}