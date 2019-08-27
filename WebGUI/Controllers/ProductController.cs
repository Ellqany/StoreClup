using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult GetStart() => View();
    }
}