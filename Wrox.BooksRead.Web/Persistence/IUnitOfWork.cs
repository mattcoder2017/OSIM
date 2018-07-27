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
         object DBAccess { get; }
         

        void Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
         private EFDBEntities _context; 
         private ReadEFDBEntities _readcontext;

        public UnitOfWork()
        {
            _context = new EFDBEntities();
            _readcontext = new ReadEFDBEntities();
        }
        public ICategoryRepository CategoryRepo
        {
            get
            {
               return new CategoryRepository(_context);
            }
        }

        public object DBAccess
        {
            get
            {
                return _context;
            }
        }

        public IProductRepository ProductRepo
        {
            get
            {
                return new ProductRepository(_context, _readcontext);
            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
