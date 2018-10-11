using System.Collections.Generic;
using DZzzz.Learning.Core.DI.Models;

namespace DZzzz.Learning.Core.DI.Repositories
{
    public class ProductRespository : IProductRepository, IActionProductRepository
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product{ Name = "1"},
            new Product{ Name = "2"}
        };

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}