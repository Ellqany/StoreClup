using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult HowitWork() => View();
        public ActionResult Clup() => View();
        public ActionResult Contact() => View();

    }
}