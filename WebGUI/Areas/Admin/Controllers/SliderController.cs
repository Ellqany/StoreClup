using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class SliderController : GenericController
    {
        readonly IImageRepository ImageRepository;

        public SliderController(IImageRepository imageRepository) => ImageRepository = imageRepository;

        public ActionResult Index() =>
          View(ImageRepository.Images.Where(x => x.Category == "Slider").ToList());

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var image = ImageRepository.Images.SingleOrDefault(x => x.ImageId == Id);
            return View(new ImageModel
            {
                ImageId = image.ImageId,
                Category = image.Category,
                Description = image.Description,
                ImageURL = image.ImageURL,
                Title = image.Title
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ImageModel image)
        {
            if (ModelState.IsValid)
            {
                image.Category = "Slider";
                if (string.IsNullOrEmpty(image.Title))
                    image.Title = " ";
                if (string.IsNullOrEmpty(image.Description))
                    image.Description = " ";
                image.ImageURL = await CreateFileUrl(image.ImageFile);
                await ImageRepository.SaveImage(image);
                TempData["Sucssess"] = "The Image has been modified successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }
    }
}