using System.Collections.Generic;
using DZzzz.Learning.Core.DI.Models;

namespace DZzzz.Learning.Core.DI.Repositories
{
    public interface IActionProductRepository
    {
        List<Product> GetProducts();
    }
}