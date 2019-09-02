using System.Collections.Generic;
using System.Linq;
using WebGUI.App_Data;

namespace WebGUI.Models
{
    public class Cart
    {
        readonly List<CartLine> LineCollection = new List<CartLine>();

        public void AddItem(Product product, int Quantity)
        {
            CartLine Line = LineCollection.
                SingleOrDefault(x => x.Product.ProductID == product.ProductID);
            if (Line == null)
            {
                LineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = Quantity
                });
            }
            else
            {
                Line.Quantity += Quantity;
            }
        }

        public void RemoveLine(Product product) =>
            LineCollection.RemoveAll(x => x.Product.ProductID == product.ProductID);

        public decimal ComputeTotalItem() =>
            LineCollection.Sum(x => x.Quantity * x.Product.Price);

        public void Clear() => LineCollection.Clear();

        public IEnumerable<CartLine> Lines => LineCollection;
    }
}