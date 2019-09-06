using System.Linq;
using System.Web.Mvc;
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
                .Where(x => Search == null || x.Email.ToLower().Contains(Search.ToLower()))
                .OrderByDescending(x => x.ContactId),
                Search = Search
            });

        public ActionResult Details(int id) =>
            View(ContactRepository.Messages.SingleOrDefault(x => x.ContactId == id));

        public JsonResult SearchResult(string Search)
        {
            var result = ContactRepository.Messages.Where(x => x.Email.ToLower().Contains(Search.ToLower()));
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}