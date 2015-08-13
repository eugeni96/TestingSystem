using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class RegistrationController : DefaultController
    {
        //
        // GET: /Registration/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Index(RegistrationViewModel user)
        {
            var blluser = new UserEntity()
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Roles = new List<RoleEntity>()
            };
            blluser.Roles.Add(new RoleEntity() { Name = "User" });
            UserService.CreateUser(blluser);

            return RedirectToAction("Index", "Home");
        }
    }
}
