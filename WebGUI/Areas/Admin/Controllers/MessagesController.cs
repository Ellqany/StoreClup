using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Areas.Admin.Models;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class MessagesController : GenericController
    {
        readonly IContactRepository ContactRepository;

        public MessagesController(IContactRepository contactRepository) =>
            ContactRepository = contactRepository;

        public ActionResult Index(string Search = null) =>
            View(new MessageModel
            {
                Messages = ContactRepository.Messages
                .Where(x => x.ContactId != 1)
                .Where(x => Search == null || x.Email.ToLower().Contains(Search.ToLower()))
                .OrderByDescending(x => x.ContactId),
                Search = Search
            });

        public ActionResult Details(int id)
        {
            if (id == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(ContactRepository.Messages.SingleOrDefault(x => x.ContactId == id));
        }

        public JsonResult SearchResult(string Search)
        {
            var result = ContactRepository.Messages
                .Where(x => x.Email.ToLower().Contains(Search.ToLower()) && x.ContactId != 1);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult EditContact()
        {
            var Message = ContactRepository.Messages.SingleOrDefault(x => x.ContactId == 1);
            return View(new ContactModel
            {
                Email = Message.Email,
                Phone = Message.Phone,
                Fax = Message.Subject,
                GoogleMapLink = Message.Name,
                Address = Message.Massage
            });
        }

        [HttpPost]
        public async Task<ActionResult> EditContact(ContactModel Message)
        {
            if (ModelState.IsValid)
            {
                await ContactRepository.SendMessage(new Contact
                {
                    Email = Message.Email,
                    Phone = Message.Phone,
                    Subject = Message.Fax,
                    Name = Message.GoogleMapLink,
                    Massage = Message.Address,
                    ContactId = 1
                });
                TempData["Success"] = "Your Message has been send successfully";
            }
            return View(Message);
        }
    }
}