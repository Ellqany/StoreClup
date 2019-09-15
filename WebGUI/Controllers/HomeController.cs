using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Areas.Admin.Models;
using WebGUI.Infrastructure;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IImageRepository ImageRepository;
        readonly IContactRepository ContactRepository;

        ContactModel GetData()
        {
            var Message = ContactRepository.Messages.SingleOrDefault(x => x.ContactId == 1);
            return new ContactModel
            {
                Email = Message.Email,
                Phone = Message.Phone,
                Fax = Message.Subject,
                GoogleMapLink = Message.Name,
                Address = Message.Massage
            };
        }

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

        public ActionResult HowitWork() =>
            View(ImageRepository.Images
                .Where(x => x.Category == "HowitWork")
                .OrderBy(x => x.Title).ToList());

        public ActionResult Club() =>
            View(ImageRepository.Images
                .Where(x => x.Category == "Club")
                .OrderBy(x => x.Title).ToList());

        public async Task<ActionResult> Contact()
        {
            var user = await CurrentUser;
            if (user is null)
            {
                return View(new Contact
                {
                    Data = GetData()
                });
            }
            else
            {
                return View(new Contact
                {
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Data = GetData()
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
                    Phone = Message.Phone,
                    Data = GetData()
                });
            }
            return View(Message);
        }
    }
}