using System.Collections.Generic;
using System.Threading.Tasks;
using WebGUI.App_Data;

namespace WebGUI.Repository.Concreate
{
    public class ProductRepository : IProductRepository
    {
        readonly ClupStoreEntities Context = new ClupStoreEntities();
        public IEnumerable<Product> Products => Context.Products;

        public async Task<Product> DeleteProduct(int productID)
        {
            Product dbEntry = await Context.Products.FindAsync(productID);
            if (dbEntry != null)
            {
                Context.Products.Remove(dbEntry);
                await Context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                Context.Products.Add(product);
            }
            else
            {
                Product dbEntry = await Context.Products.FindAsync(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageUrl = product.ImageUrl;
                    dbEntry.SuppscriptionLink = product.SuppscriptionLink;
                }
            }
            await Context.SaveChangesAsync();
        }

    }
}