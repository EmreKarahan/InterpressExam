using System.Web.Mvc;

namespace InterpressExam.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult RssItems()
        {
            return PartialView("_RssItems");
        }
    }
}