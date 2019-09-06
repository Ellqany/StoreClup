using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class OrderRepository : IOrderRepository
    {
        readonly ClupStoreEntities context = new ClupStoreEntities();
        public IEnumerable<Order> Orders => context.Orders;

        public async Task SaveOrder(Order order)
        {
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            await context.SaveChangesAsync();
        }
    }
}