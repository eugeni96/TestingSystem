using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class LoginController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginViewModel.Name, loginViewModel.Password, loginViewModel.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Passwords do not match");
            }
            return View(loginViewModel);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
