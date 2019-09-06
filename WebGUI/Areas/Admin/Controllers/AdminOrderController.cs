using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebGUI.Areas.Admin.Models;
using WebGUI.Repository;

namespace WebGUI.Areas.Admin.Controllers
{
    public class AdminOrderController : GenericController
    {
        readonly IOrderRepository OrderRepository;

        public AdminOrderController(IOrderRepository orderRepository) =>
            OrderRepository = orderRepository;

        public ActionResult Index(string Search = null)
            => View(new OrderModel
            {
                Orders = OrderRepository.Orders
                .Where(x => Search == null || x.AspNetUser.Name.ToLower().Contains(Search.ToLower()))
                .OrderByDescending(x => x.RegisteratedDate),
                Search = Search
            });
        [HttpPost]
        public async Task<ActionResult> MarkShipped(int orderID, string ReturnUrl)
        {
            var order = OrderRepository.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                await OrderRepository.SaveOrder(order);
            }
            return Redirect(ReturnUrl);
        }

        public ActionResult Details(int id) =>
            View(OrderRepository.Orders.SingleOrDefault(x => x.OrderID == id));

        public JsonResult SearchResult(string Search)
        {
            var result = OrderRepository.Orders
                .Where(x => x.AspNetUser.Name.ToLower().Contains(Search.ToLower()))
                .Select(x => x.AspNetUser.Name).ToList();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}