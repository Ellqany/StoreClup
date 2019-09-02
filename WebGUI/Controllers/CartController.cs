using System.Linq;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    public class CartController : Controller
    {
        readonly IProductRepository Reposatory;
        readonly IOrderRepository OrderRepository;

        public CartController(IProductRepository Repo, IOrderRepository order)
        {
            Reposatory = Repo;
            OrderRepository = order;
        }

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

        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public ViewResult Checkout(Cart cart, Order Order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                OrderRepository.SaveOrder(cart, Order);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(Order);
            }
        }
    }
}