using System.Linq;
using System.Web.Mvc;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IImageRepository ImageRepository;

        public HomeController(IImageRepository imageRepository) => ImageRepository = imageRepository;

        public ActionResult Index() =>
            View(ImageRepository.Images
                .Where(x => x.Category == "Home")
                .OrderBy(x => x.Title).ToList());

        public ActionResult HowitWork() => View();
        public ActionResult Clup() => View();
        public ActionResult Contact() => View();

    }
}