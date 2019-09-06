using Microsoft.AspNet.Identity.Owin;
using PayPal.Api;
using System;
using System.Collections.Generic;
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
        readonly IOrderRepository OrderRepository;
        AppUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        Task<AppUser> CurrentUser =>
            UserManager.FindByNameAsync(HttpContext.User.Identity.Name);

        public OrderController(IOrderRepository repoService) =>
            OrderRepository = repoService;
        [HttpGet]
        public async Task<ActionResult> Checkout()
        {
            var user = await CurrentUser;
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
                return RedirectToAction(nameof(PaymentWithPaypal));
            }
            var user = await CurrentUser;
            Order.User = user;
            Order.UserId = user.Id;
            return View(Order);
        }
        [HttpGet]
        public ViewResult Completed(Cart cart)
        {
            cart.Clear();
            return View();
        }

        #region Paypall
        public Payment Payment { get; set; }

        public async Task<ActionResult> PaymentWithPaypal(Cart cart)
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority +
                                "/Order/PaymentWithPaypal?";

                    var guid = Convert.ToString((new Random()).Next(100000));

                    var createdPayment = this.CreatePayment(cart, apiContext, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = null;

                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("Error", new string[] { executedPayment.failure_reason });
                    }
                }
            }
            catch (Exception)
            {
                return View("Error", new string[] { "Failed to make payment please try again" });
            }
            await MakeCurrentOrder(cart, cart.CurrentOrder);
            return RedirectToAction(nameof(Completed));
        }

        Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.Payment = new Payment() { id = paymentId };
            return this.Payment.Execute(apiContext, paymentExecution);
        }

        Payment CreatePayment(Cart cart, APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };

            foreach (var item in cart.Lines)
            {
                itemList.items.Add(new Item()
                {
                    name = item._Product.Name,
                    currency = "USD",
                    price = item._Product.Price.ToString(),
                    quantity = item.Quantity.ToString(),
                    sku = "sku"
                });
            }

            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "14",
                subtotal = cart.ComputeTotalItem().ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (15 + cart.ComputeTotalItem()).ToString(),
                details = details
            };

            var guid = Convert.ToString((new Random()).Next(100000));

            var transactionList = new List<Transaction>
            {
                new Transaction()
                {
                    description = "Bath clup pill register",
                    invoice_number = guid.ToString(),
                    amount = amount,
                    item_list = itemList
                }
            };

            this.Payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return this.Payment.Create(apiContext);
        }
        #endregion

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
        #endregion
    }
}