using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories();
    }
    public class CategoryRepository : ICategoryRepository
    {
        EFConnection _context;
        public CategoryRepository()
        {
            _context = new EFConnection();
        }
        public IEnumerable<Category> AllCategories()
        {
            return _context.Categories.ToList<Category>();
        }
    }
}