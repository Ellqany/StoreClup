using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Infrastructure;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IImageRepository ImageRepository;
        readonly IContactRepository ContactRepository;
        AppUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        Task<AppUser> CurrentUser =>
            UserManager.FindByNameAsync(HttpContext.User.Identity.Name);

        public HomeController(IImageRepository imageRepository,
            IContactRepository contactRepository)
        {
            ImageRepository = imageRepository;
            ContactRepository = contactRepository;
        }

        public ActionResult Index() =>
            View(ImageRepository.Images
                .Where(x => x.Category == "Home")
                .OrderBy(x => x.Title).ToList());

        public ActionResult HowitWork() => View();

        public async Task<ActionResult> Contact()
        {
            var user = await CurrentUser;
            if (user is null)
            {
                return View();
            }
            else
            {
                return View(new Contact
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Contact(Contact Message)
        {
            if (ModelState.IsValid)
            {
                await ContactRepository.SendMessage(Message);
                TempData["Success"] = "Your Message has been send successfully";
                return View(new Contact
                {
                    Name = Message.Name,
                    Email = Message.Email,
                    Phone = Message.Phone
                });
            }
            return View(Message);
        }
    }
}