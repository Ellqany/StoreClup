using System.Linq;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        readonly IProductRepository Reposatory;

        public CartController(IProductRepository Repo) =>
            Reposatory = Repo;

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int ProductID, string ReturnUrl)
        {
            Product product = Reposatory.Products.FirstOrDefault(x => x.ProductID == ProductID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { ReturnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int ProductID, string ReturnUrl)
        {
            Product product = Reposatory.Products.FirstOrDefault(x => x.ProductID == ProductID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { ReturnUrl });
        }
    }
}