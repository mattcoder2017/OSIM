using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Repository;

namespace Wrox.BooksRead.Web.Persistence
{
    public interface IUnitOfWork
    {
         IProductRepository ProductRepo { get;}
         ICategoryRepository CategoryRepo { get;  }

        void Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private EFDBEntities _context; 
        public UnitOfWork()
        {
            _context = new EFDBEntities();
        }
        public ICategoryRepository CategoryRepo
        {
            get
            {
               return new CategoryRepository(_context);
            }
        }

        public IProductRepository ProductRepo
        {
            get
            {
                return new ProductRepository(_context);
            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
