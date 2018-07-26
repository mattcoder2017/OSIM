using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wrox.BooksRead.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        { }
        public ProductViewModel(Product product, IEnumerable<Category> categories )
        {
            if (product != null)
            { 
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.Category;
            CreateDate = product.CreateDate.Date.ToString();
            CreatTime = product.CreateDate.TimeOfDay.ToString();
            Category1 = product.Category1;
                Price = product.Price;
                Stock = product.Stock;
            }
            Categories = categories;
         }

        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Display(Name ="Category Name")]
        public int CategoryId { get; set; }
        [Required]
        [DateValidation]
        public String CreateDate { get; set; }
        //[Required]
        //[DateValidation]
        public String CreatTime { get; set; }

        public Category Category1 { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }
        public int? Price { get;  set; }
        public int? Stock { get;  set; }
    }
}