namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductUserSubscription")]
    public partial class ProductUserSubscription
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
