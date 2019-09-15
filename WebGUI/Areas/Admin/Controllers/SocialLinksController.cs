using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class SocialLinksController : GenericController
    {
        #region Private Variables
        readonly ISocialLinkRepository SocialLinkRepository;
        #endregion

        #region Constractor
        public SocialLinksController(ISocialLinkRepository repo) => SocialLinkRepository = repo;
        #endregion

        public ActionResult Index() => View(SocialLinkRepository.SocialLinks.ToList());

        [HttpPost]
        public async Task<ActionResult> Index(List<SocialLink> link)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in link)
                {
                    await SocialLinkRepository.SaveLink(item);
                    TempData["Success"] = "Links has been updated successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(link);
        }

    }
}