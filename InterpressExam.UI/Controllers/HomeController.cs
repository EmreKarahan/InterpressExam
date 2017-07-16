using System.Web.Mvc;
using InterpressExam.Data.Contract;

namespace InterpressExam.UI.Controllers
{
    public class HomeController : Controller
    {
        private IRssItemRepository _itemRepository;

        public HomeController(IRssItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
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