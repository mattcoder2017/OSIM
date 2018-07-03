using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProduct();
        bool AddProduct(ProductViewModel product);
        Product GetProductById(int? productid);
        bool EditProduct(ProductViewModel product);
        void Delete(int id);
    }
    public class HardCodedProductRepository : IProductRepository
    {
        public bool AddProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> AllProduct()
        {
            return new List<Product>()
            {
                new Product {Id=0, Name="xxx"},
                new Product {Id=1, Name="YYY"}
            };
        }

        Product IProductRepository.GetProductById(int? productid)
        {
            throw new NotImplementedException();
        }
        public bool EditProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }


    }

    public class ProductRepository : IProductRepository
    {
        IEFDBEntities _context = null;
        public ProductRepository()
        {
            // _context = new EFDBEntities();

        }

        public ProductRepository(IEFDBEntities _context)
        {
            this._context = _context;
        }

        public bool AddProduct(ProductViewModel product)
        {
            try
            {
                Product p = new Product();
                p.Id = product.Id;
                p.Name = product.Name;
                p.Category = product.CategoryId;
                p.CreateDate = DateTime.Parse(product.CreateDate);

                _context.Products.Add(p);
               // _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
                
        }

        public IEnumerable<Product> AllProduct()
        {
            return _context.Products.Where(p=>p.CreateDate > DateTime.Today).Include(p => p.Category1).ToList<Product>();
        }

        public bool EditProduct(ProductViewModel vmproduct)
        {
            try
            {
                Product product = new Product();
                product.Id = vmproduct.Id;
                product.Name = vmproduct.Name;
                product.Category = vmproduct.CategoryId;
                product.CreateDate = DateTime.Parse(vmproduct.CreateDate);
                //_context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                //_context.SaveChanges();
                return true;
            }
            catch
            {
                // log things to logger
            }
            finally
            {
            }
            return false;
        }
        public Product GetProductById(int? productid)
        {
            return _context.Products
                 .Where(i => i.Id == productid)
                 .Include(i => i.ProductNotifications)
                 .Include(i => i.ProductSubscriptions).FirstOrDefault<Product>();

        }

        public void Delete(int Id)
        {
            Product p = _context.Products.Single<Product>(a => a.Id == Id);
            _context.Products.Remove(p);
            //_context.SaveChanges();
        }
    }


}

