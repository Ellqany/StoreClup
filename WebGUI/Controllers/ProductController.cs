using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebGUI.App_Data;
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

        public ActionResult Customize(List<int> id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(GetStart));
            }
            List<Product> Result = new List<Product>();
            foreach (var item in id)
            {
                var Product = ProductRepository.Products
                    .SingleOrDefault(x => x.ProductID == item);
                Result.Add(Product);
            }
            return View(Result);
        }
    }
}