using System.Linq;
using System.Web.Mvc;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class NavController : Controller
    {
        readonly IImageRepository ImageRepository;
        public NavController(IImageRepository ImageRepository) => this.ImageRepository = ImageRepository;

        public PartialViewResult SlideShow() =>
            PartialView(ImageRepository.Images.
                Where(x => x.Category == "Slider").ToList());
    }
}