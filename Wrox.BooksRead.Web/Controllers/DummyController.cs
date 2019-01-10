using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;
using Wrox.BooksRead.Web.Repository;

namespace Wrox.BooksRead.Web.Controllers
{
    [Authorize]
    public class DummyController : Controller
    {
        private IUnitOfWork unitOfWork;
        
        public DummyController(IUnitOfWork UnitOfWork)
        {
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

        
        public ViewResult GetAllAction()
        {
            var Data = this.unitOfWork.ProductRepo.AllProduct();
            return View(Data);
        }


        [HttpPost]
        public ActionResult AddProductToDB(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (this.unitOfWork.ProductRepo.AddProduct(product))
                {
                    unitOfWork.Complete();
                    return RedirectToAction("GetAllAction", "Dummy");
                }
                else
                    return View("Create", product);
            }
            
            product.Categories = RedisLib.GetCache<IEnumerable<Category>>("Categories", () => { return unitOfWork.CategoryRepo.AllCategories(); });
            // CategoryRepository.AllCategories();
            return View("GetAllAction");
        }

        [HttpPost]
        public ActionResult EditProductToDB(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Product originalproduct = unitOfWork.ProductRepo.GetProductByIdWithUpdate(product.Id);
                originalproduct.Update(product);
                //db.Entry(originalproduct).State = EntityState.Modified;
                if (originalproduct.PriceIsChanged)
                {
                    unitOfWork.NotificationRepo.buildPriceChangeNotification(originalproduct, originalproduct.ProductSubscriptions, originalproduct.ProductNotifications.GetEnumerator().Current);
                }
                unitOfWork.Complete();
            }
            return RedirectToAction("GetAllAction", "Dummy");
        }

        public ActionResult Edit(int? Id)
        {
            Product product = unitOfWork.ProductRepo.GetProductById(Id);
            if (product == null) 
               return HttpNotFound();
            ProductViewModel viewModel = new ProductViewModel(product, this.unitOfWork.CategoryRepo.AllCategories());
            return View(viewModel);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            ProductViewModel viewModel = new ProductViewModel(product, this.unitOfWork.CategoryRepo.AllCategories());
            return View(viewModel);
        }
    }

    
}