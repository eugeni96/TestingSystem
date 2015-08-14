using System.Web.Mvc;

namespace MvcPL.Controllers
{
    public class HomeController : DefaultController
    {

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}