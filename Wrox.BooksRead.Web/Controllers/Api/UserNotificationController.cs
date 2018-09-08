using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wrox.BooksRead.Web.DTO;
using Wrox.BooksRead.Web.Models;
using Wrox.BooksRead.Web.Persistence;

namespace Wrox.BooksRead.Web.Controllers.Api
{
    [System.Web.Http.RoutePrefix("api/UserNotification")]
    [Authorize]
    public class UserNotificationController : ApiController
    {
        IUnitOfWork UnitOfWork;

        public  UserNotificationController(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        [HttpGet]
        public IEnumerable<UserProductNoticationDTO> GetUserNotification(string userid)
            {
            if (userid == null)
            {
                userid = User.Identity.GetUserId();
            }
            Mapper.CreateMap<UserProductNotification, UserProductNoticationDTO>();
            var notifications = UnitOfWork.UserNotificationRepo.GetUserNotification(userid);
            return notifications.Select(Mapper.Map<UserProductNotification, UserProductNoticationDTO>);
          
        }

        [HttpGet]
        public IEnumerable<UserProductNoticationDTO> GetUserNotification()
        {
            
            string    userid = User.Identity.GetUserId();
            
            Mapper.CreateMap<UserProductNotification, UserProductNoticationDTO>();
            var notifications = UnitOfWork.UserNotificationRepo.GetUserNotification(userid);
            return notifications.Select(Mapper.Map<UserProductNotification, UserProductNoticationDTO>);

        }

    }
}
