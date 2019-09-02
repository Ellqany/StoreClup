using System.Linq;
using WebGUI.App_Data;
using WebGUI.Models;

namespace WebGUI.Repository.Concreate
{
    public class OrderRepository : IOrderRepository
    {
        readonly ClupStoreEntities context = new ClupStoreEntities();
        public IQueryable<Order> Orders => context.Orders;

        public void SaveOrder(Cart cart, Order order)
        {
            //context.AttachRange(order.CartLines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}