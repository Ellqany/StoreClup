using System.Linq;
using System.Web.Mvc;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class NavController : Controller
    {
        readonly IImageRepository ImageRepository;
        readonly ISocialLinkRepository SocialLinkRepository;

        public NavController(IImageRepository ImageRepository,
            ISocialLinkRepository SocialLinkRepository)
        {
            this.ImageRepository = ImageRepository;
            this.SocialLinkRepository = SocialLinkRepository;
        }

        public PartialViewResult SlideShow() =>
            PartialView(ImageRepository.Images.
                Where(x => x.Category == "Slider").ToList());

        public PartialViewResult Social() =>
            PartialView(SocialLinkRepository.SocialLinks.ToList());
    }
}