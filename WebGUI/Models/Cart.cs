using System.Collections.Generic;
using System.Linq;
using WebGUI.App_Data;

namespace WebGUI.Models
{
    public class Cart
    {
        readonly List<CartLine> LineCollection = new List<CartLine>();

        public Order CurrentOrder { get; set; }

        public void AddItem(Product product, int Quantity)
        {
            CartLine Line = LineCollection.
                SingleOrDefault(x => x._Product.ProductID == product.ProductID);
            if (Line == null)
            {
                LineCollection.Add(new CartLine
                {
                    _Product = product,
                    Quantity = Quantity,
                    ProductID = product.ProductID
                });
            }
            else
            {
                Line.Quantity += Quantity;
            }
        }

        public void RemoveLine(Product product) =>
            LineCollection.RemoveAll(x => x._Product.ProductID == product.ProductID);

        public decimal ComputeTotalItem() =>
            LineCollection.Sum(x => x.Quantity * x._Product.Price);

        public void Clear() => LineCollection.Clear();

        public IEnumerable<CartLine> Lines => LineCollection;
    }
}