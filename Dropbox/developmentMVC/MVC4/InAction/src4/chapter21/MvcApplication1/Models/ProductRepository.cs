using System.Collections.Generic;
using System.Linq;

namespace HostingSample.Models
{
    public class ProductRepository
    {
        private static readonly Product[] _products = new[]
        {
            new Product
            {
                Id = 1,
                Name = "Basketball",
                Description = "You bounce it."
            },
            new Product
            {
                Id = 2,
                Name = "Baseball",
                Description = "You throw it."
            },
            new Product
            {
                Id = 3,
                Name = "Football",
                Description = "You punt it."
            },
            new Product
            {
                Id = 4,
                Name = "Golf ball",
                Description = "You hook or slice it."
            }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(x => x.Id == id);
        }
    }
}