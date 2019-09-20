using System.Linq;
using System.Web.Mvc;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        readonly IProductRepository ProductRepository;

        public ProductController(IProductRepository repo) => ProductRepository = repo;

        public ActionResult GetStart() =>
            View(ProductRepository.Products.ToList());

        public ActionResult Customize(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(GetStart));
            }
            var Product = ProductRepository.Products
                .SingleOrDefault(x => x.ProductID == id);
            return View(Product);
        }
    }
}