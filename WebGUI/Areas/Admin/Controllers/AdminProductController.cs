using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class AdminProductController : GenericController
    {
        readonly IProductRepository ProductRepository;

        public AdminProductController(IProductRepository repo) => ProductRepository = repo;

        public ViewResult Index() => View(ProductRepository.Products);

        public ViewResult Edit(int productId)
        {
            Product product = ProductRepository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                product.ImageUrl = await CreateFileUrl(Image, product.ImageUrl);
                product.Category = "new";
                await ProductRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public async Task<ActionResult> Delete(int productId)
        {
            Product deletedProduct = await ProductRepository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return PartialView("GetProducts", ProductRepository.Products);
        }
    }
}