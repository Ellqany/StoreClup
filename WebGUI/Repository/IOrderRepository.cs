using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        Task SaveOrder(Order order);
    }
}