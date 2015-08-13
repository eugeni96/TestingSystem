using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Global.Auth;
using MvcPL.Mappers;
using Ninject;

namespace MvcPL.Controllers
{
    public class BaseController : Controller
    {

        protected static string ErrorPage = "~/Error";
        protected static string NotFoundPage = "~/NotFoundPage";
        protected static string LoginPage = "~/Login";

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        public UserEntity CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }

        public RedirectResult RedirectToNotFoundPage
        {
            get
            {
                return Redirect(NotFoundPage);
            }
        }

        public RedirectResult RedirectToLoginPage
        {
            get
            {
                return Redirect(LoginPage);
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Result = Redirect(ErrorPage);
        }

    }
}
