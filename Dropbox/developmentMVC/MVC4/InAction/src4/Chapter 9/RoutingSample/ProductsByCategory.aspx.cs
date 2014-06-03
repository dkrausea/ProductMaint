using System;
using System.Web.UI;
using RoutingSample.Models;

namespace RoutingSample
{
	public partial class ProductsByCategory : Page
	{
		private readonly ProductRepository _productRepository = new ProductRepository();

		protected void Page_Load(object sender, EventArgs e)
		{
            string category = (string)RouteData.Values["category"];
			var productsByCategory = _productRepository.GetProductsByCategory(category);

			_groupedProductsRepeater.DataSource = productsByCategory;
			_groupedProductsRepeater.DataBind();
		}
	}
}