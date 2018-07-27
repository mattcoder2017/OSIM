namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProductNotification")]
    public partial class UserProductNotification
    {
        public int Id { get; set; }

        public int ProductNotificationId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int IsRead { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual ProductNotification ProductNotification { get; set; }
    }
}
