namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductNotifications = new HashSet<ProductNotification>();
            ProductSubscriptions = new HashSet<ProductSubscription>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Category { get; set; }

        public DateTime CreateDate { get; set; }

        public int? Stock { get; set; }

        public int? Price { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductNotification> ProductNotifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSubscription> ProductSubscriptions { get; set; }
        public bool PriceIsChanged { get; private set; }
        public void Update(ProductViewModel priceChangeProduct)
         {              
             if (this.Price != priceChangeProduct.Price) 
             { 
                 this.PriceIsChanged = true; 
                 var productNotification = new ProductNotification(); 
                 productNotification.Notification = 
                     string.Format(Common.Utility.PRODUCT_PRICE_CHANGE_NOTIFICATION,
                     new object[] { 
                         this.Id.ToString(), 
                         this.Name, 
                         this.Price.ToString(), 
                         priceChangeProduct.Price.ToString() }); 
 
 
                 this.ProductNotifications.Add(productNotification); 
             } 
         } 

    }
}
