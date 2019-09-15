using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class ClubController : GenericController
    {
        readonly IImageRepository ImageRepository;

        public ClubController(IImageRepository imageRepository)
            => ImageRepository = imageRepository;

        public ActionResult Index() =>
            View(ImageRepository.Images
                .Where(x => x.Category == "Club")
                .OrderBy(x => x.Title).ToList());

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var image = ImageRepository.Images.SingleOrDefault(x => x.ImageId == id);
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
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(ImageModel image)
        {
            if (ModelState.IsValid)
            {
                image.Category = "Club";
                if (string.IsNullOrEmpty(image.Description))
                    image.Description = " ";
                image.ImageURL = await CreateFileUrl(image.ImageFile, image.ImageURL);
                await ImageRepository.SaveImage(image);
                TempData["Sucssess"] = "The Image has been modified successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }
    }
}