using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class HomeController : DefaultController
    {

        
        public ActionResult Index()
        {
            return View(UserService.GetAllUserEntities()
                .Select(user => new UserViewModel()
                {
                    UserName = user.UserName
                }));
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}