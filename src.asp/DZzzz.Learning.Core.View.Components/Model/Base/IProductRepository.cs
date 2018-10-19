using System.Collections.Generic;

namespace DZzzz.Learning.Core.View.Components.Model.Base
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void AddProduct(Product newProduct);
    }
}