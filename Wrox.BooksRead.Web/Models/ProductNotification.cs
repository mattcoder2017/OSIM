namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductNotification")]
    public partial class ProductNotification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductNotification()
        {
            UserProductNotifications = new HashSet<UserProductNotification>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Notification { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProductNotification> UserProductNotifications { get; set; }
    }
}
