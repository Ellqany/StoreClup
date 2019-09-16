using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.App_Data;
using WebGUI.Infrastructure;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        readonly IProductRepository Reposatory;
        readonly IOrderRepository OrderRepository;
        AppUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        Task<AppUser> CurrentUser =>
            UserManager.FindByNameAsync(HttpContext.User.Identity.Name);

        public OrderController(IOrderRepository repoService, IProductRepository Repo)
        {
            OrderRepository = repoService;
            Reposatory = Repo;
        }

        [HttpGet]
        public async Task<ActionResult> Checkout(Cart cart, int Id)
        {
            var user = await CurrentUser;
            AddToCart(cart, Id);
            return View(new App_Data.Order()
            {
                User = user,
                UserId = user.Id
            });
        }
        [HttpPost]
        public async Task<ActionResult> Checkout(Cart cart, App_Data.Order Order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                cart.CurrentOrder = Order;
                int? id = cart.Lines.FirstOrDefault().ProductID;
                return Redirect(Reposatory.Products
                    .SingleOrDefault(x => x.ProductID == id).SuppscriptionLink);
            }
            var user = await CurrentUser;
            Order.User = user;
            Order.UserId = user.Id;
            return View(Order);
        }
        [HttpGet]
        public async Task<ActionResult> Completed(Cart cart)
        {
            if (cart.Lines.Count() == 0)
            {
                return RedirectToAction("GetStart", "Product", null);
            }
            await MakeCurrentOrder(cart, cart.CurrentOrder);
            cart.Clear();
            return View();
        }

        #region Private Methods
        async Task MakeCurrentOrder(Cart cart, App_Data.Order Order)
        {
            foreach (var item in cart.Lines)
            {
                Order.CartLines.Add(item);
            }
            Order.RegisteratedDate = DateTime.Now;
            Order.RenewDate = NextMonth(Order.RegisteratedDate);
            Order.Baid = true;
            await OrderRepository.SaveOrder(Order);
        }

        DateTime NextMonth(DateTime date)
        {
            if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
                return date.AddMonths(1);
            else
                return date.AddDays(1).AddMonths(1).AddDays(-1);
        }

        void AddToCart(Cart cart, int Id)
        {
            cart.Clear();
            Product product = Reposatory.Products.FirstOrDefault(x => x.ProductID == Id);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
        }
        #endregion
    }
}