using System.Linq;
using WebGUI.App_Data;
using WebGUI.Models;

namespace WebGUI.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Cart cart, Order order);
    }
}