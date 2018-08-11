using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrox.BooksRead.Web.Models;

namespace Wrox.BooksRead.Web.Repository
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserProductNotification> GetUserNotification(string userId);
    }

    public class UserNotificationRepository : IUserNotificationRepository
    {
        IEFDBEntities context;
        IEFDBEntities readcontext;

        public UserNotificationRepository(IEFDBEntities context, IEFDBEntities readcontext)
        {
            this.context = context;
            this.readcontext = readcontext;

        }
        public IEnumerable<UserProductNotification> GetUserNotification(string userId)
        {
            var userNotifications = context.UserProductNotifications.Where
                (e => e.UserId == userId)
                .Include(p => p.ProductNotification);
            return userNotifications;
                
                
        }
    }

}
