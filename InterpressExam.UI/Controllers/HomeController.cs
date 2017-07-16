using System.Web.Mvc;
using InterpressExam.Data.Contract;

namespace InterpressExam.UI.Controllers
{
    public class HomeController : Controller
    {
        private IRssItemRepository _rssItemRepository;

        public HomeController(IRssItemRepository rssItemRepository)
        {
            _rssItemRepository = rssItemRepository;
        }

        public ActionResult Index()
        {
            var rssList = _rssItemRepository.RssItemGetList();
            return View();
        }

        //[ChildActionOnly]
        public PartialViewResult RssItems()
        {
            return PartialView("_RssItems");
        }
    }
}