using System;
using System.Collections.Generic;
using System.Linq;

namespace RoutingSample.Models
{
	public class ProductRepository
	{
		private static readonly IList<Product> _products = new List<Product>
		{
			new Product { Id = 1, Code = "iphone-4", Name = "iPhone 4", Category = "Cell Phones"},
			new Product { Id = 2, Code = "windows-phone", Name = "Windows Phone 7", Category = "Cell Phones"},
			new Product { Id = 3, Code = "asp-mvc-in-action", Name = "ASP.NET MVC 3 in Action", Category = "Books" },
			new Product { Id = 4, Code = "linq-in-action", Name = "Linq in Action", Category = "Books"},
			new Product { Id = 5, Code = "csharp-in-depth", Name = "C# in Depth", Category = "Books"},

		};

		public IEnumerable<Product> GetAllProducts()
		{
			return _products;
		}

		public Product GetByCode(string code)
		{
			return _products.SingleOrDefault(x => x.Code == code);
		}

		public IEnumerable<ProductGrouping> GetProductsByCategory(string category)
		{
			var groupedByCategory = from product in _products
									group product by product.Category into grouping
									select new ProductGrouping
									{
										Category = grouping.Key,
										Products = grouping.ToArray()
									};

			// If a category has been specified, and that category is not equal to "All" then filter on that category.
			if(category != null && !string.Equals(category, "all", StringComparison.OrdinalIgnoreCase))
			{
				groupedByCategory = groupedByCategory.Where(x => x.Category == category);
			}

			return groupedByCategory.ToList();
		}
	}
}