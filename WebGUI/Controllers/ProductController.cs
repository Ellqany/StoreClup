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

        public ActionResult Details(int id) =>
            View(ProductRepository.Products.SingleOrDefault(x => x.ProductID == id));
    }
}