using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Repository;

namespace Wrox.BooksRead.Web.Controllers
{
    public class DummyController : Controller
    {
        private IProductRepository ProductRepository;
        private ICategoryRepository CategoryRepository;

        
        public DummyController(IProductRepository moqProductRepository, ICategoryRepository cateRepo)
        {
            this.ProductRepository = moqProductRepository;
            this.CategoryRepository = cateRepo;
        }

        public DummyController()
        {
        }
        //public DummyController()
        //{
        //    //this.ProductRepository = new HardCodedProductRepository();
        //    this.ProductRepository = new ProductRepository();
        //    this.CategoryRepository = new CategoryRepository();
        //}

        // GET: Dummy
        public ActionResult Dumb()
        {
            return View();
        }

        public ActionResult GetAllAction()
        {
            var Data = this.ProductRepository.AllProduct();
            return View(Data);
        }

        public ActionResult Create()
        {
            var viewmodel = new ProductViewModel(null,
                RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return CategoryRepository.AllCategories(); } ));
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddProductToDB(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (ProductRepository.AddProduct(product))
                    return RedirectToAction("Index", "Home");
                else
                    return View("Create", product);
            }
            product.Categories = RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return CategoryRepository.AllCategories(); });// CategoryRepository.AllCategories();
            return View("GetAllAction");
        }

        [HttpPost]
        public ActionResult EditProductToDB(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (ProductRepository.EditProduct(product))
                    return RedirectToAction("GetAllAction", "Dummy");
                else
                    return View("Edit", product);
            }
            //product.Categories = RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return CategoryRepository.AllCategories(); });// CategoryRepository.AllCategories();
            return RedirectToAction("GetAllAction", "Dummy");
        }

        public ActionResult Edit(int? Id)
        {
            Product product = ProductRepository.GetProductById(Id);
            //ProductViewModel viewModel = new ProductViewModel(product, CategoryRepository.AllCategories());
            ProductViewModel viewModel = new ProductViewModel(product, RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return CategoryRepository.AllCategories(); }));
            return View(viewModel);
        }
    }

    
}