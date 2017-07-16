using System.Web.Mvc;
using InterpressExam.Data.Contract;

namespace InterpressExam.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        //[ChildActionOnly]
        public PartialViewResult RssItems()
        {
            return PartialView("_RssItems");
        }
    }
}