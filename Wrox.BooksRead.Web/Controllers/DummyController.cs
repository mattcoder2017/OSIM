using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;
using Wrox.BooksRead.Web.Repository;

namespace Wrox.BooksRead.Web.Controllers
{
    [Authorize]
    public class DummyController : Controller
    {
        private IProductRepository ProductRepository;
        private ICategoryRepository CategoryRepository;
        private IUnitOfWork unitOfWork;

        
        public DummyController(IProductRepository moqProductRepository, ICategoryRepository cateRepo, IUnitOfWork UnitOfWork)
        {
            this.ProductRepository = moqProductRepository;
            this.CategoryRepository = cateRepo;
            this.unitOfWork = UnitOfWork;
        }

        public DummyController()
        {
        }
       

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
            
            product.Categories = RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return CategoryRepository.AllCategories(); });
            // CategoryRepository.AllCategories();
            return View("GetAllAction");
        }

        [HttpPost]
        public ActionResult EditProductToDB(ProductViewModel product)
        {
             if (ModelState.IsValid)
            {
                Product originalproduct = unitOfWork.ProductRepo.GetProductById(product.Id);
                originalproduct.Update(product);
                unitOfWork.Complete();
               
                return RedirectToAction("GetAllAction", "Dummy");
              
            }
            return RedirectToAction("GetAllAction", "Dummy");
        }

        public ActionResult Edit(int? Id)
        {
            Product product = unitOfWork.ProductRepo.GetProductById(Id); 
            ProductViewModel viewModel = new ProductViewModel(product, CategoryRepository.AllCategories());
            return View(viewModel);
        }
    }

    
}