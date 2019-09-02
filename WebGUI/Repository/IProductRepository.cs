using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Task SaveProduct(Product product);
        Task<Product> DeleteProduct(int productID);
    }
}