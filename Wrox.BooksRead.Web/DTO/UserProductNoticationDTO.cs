using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.DTO
{
    public class UserProductNoticationDTO
    {
      
            public int Id { get; set; }

            public int ProductNotificationId { get; set; }

            public String UserId { get; set; }

            public int IsRead { get; set; }

            public String NotificationMessage { get; set; }
       
    }
}