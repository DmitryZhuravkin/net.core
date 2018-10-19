using System.Collections.Generic;
using DZzzz.Learning.Core.View.Components.Model.Base;

namespace DZzzz.Learning.Core.View.Components.Model
{
    public class MemoryProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product> {
            new Product { Name = "Kayak", Price = 275M },
            new Product { Name = "Lifejacket", Price = 48.95M },
            new Product { Name = "Soccer ball", Price = 19.50M }
        };

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product newProduct)
        {
            products.Add(newProduct);
        }
    }
}