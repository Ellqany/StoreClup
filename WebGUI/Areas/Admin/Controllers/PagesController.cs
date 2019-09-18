using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class PagesController : GenericController
    {
        readonly IPageRepository PageRepository;

        public PagesController(IPageRepository pageRepository) =>
            PageRepository = pageRepository;

        [HttpGet]
        public ActionResult Privacy() =>
            View(PageRepository.Pages.SingleOrDefault(x => x.Category == "Privacy"));
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Privacy(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Category = "Privacy";
                page.Description = (string.IsNullOrEmpty(page.Description)) ? "Privacy" : page.Description;
                await PageRepository.SavePage(page);
                TempData["success"] = "Privacy has been updated successfully";
                return RedirectToAction(nameof(Privacy));
            }
            return View(page);
        }
        [HttpGet]
        public ActionResult Terms() =>
            View(PageRepository.Pages.SingleOrDefault(x => x.Category == "Terms"));
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Terms(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Category = "Terms";
                page.Description = (string.IsNullOrEmpty(page.Description)) ? "Terms" : page.Description;
                await PageRepository.SavePage(page);
                TempData["success"] = "Terms has been updated successfully";
                return RedirectToAction(nameof(Terms));
            }
            return View(page);
        }
    }
}