using System.Web.Mvc;

namespace UI.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}