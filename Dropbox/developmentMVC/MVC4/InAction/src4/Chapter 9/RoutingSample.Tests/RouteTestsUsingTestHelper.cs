using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using RoutingSample.Controllers;

namespace RoutingSample.Tests
{
	[TestFixture]
	public class UsingTestHelper
	{
		/*  Desired URL schema:
		 * 1.  example.com/                     home page
		 * 2.  example.com/privacy              static page containing privacy policy
		 * 3.  example.com/products              show a list of the products
		 * 4.  example.com/<product code>	    Shows a product detail page for the relevant <product code>
		 * 5.  example.com/<product code>/buy	Add the relevant product to the shopping basket
		 * 6.  example.com/basket	            Shows the current users shopping basket
		 * 7.  example.com/checkout	            Starts the checkout process for the current user
		 * 8.  example.com/404                  show a friendly 404 page
		 */

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			RouteTable.Routes.Clear();
			MvcApplication.RegisterRoutes(RouteTable.Routes);
		}

		[Test]
		public void root_maps_to_home_index()
		{
			"~/".ShouldMapTo<HomeController>(x => x.Index());
		}

		[Test]
		public void privacy_should_map_to_home_privacy()
		{
			"~/privacy".ShouldMapTo<HomeController>(x => x.Privacy());
		}

		[Test]
		public void products_should_map_to_catalog_index()
		{
			"~/products".ShouldMapTo<CatalogController>(x => x.Index());
		}

		[Test]
		public void product_code_url()
		{
			"~/products/product-1".ShouldMapTo<CatalogController>(x => x.Show("product-1"));
		}

		[Test]
		public void product_buy_url()
		{
			"~/products/product-1/buy".ShouldMapTo<CatalogController>(x => x.Buy("product-1"));
		}

		[Test]
		public void basket_should_map_to_catalog_basket()
		{
			"~/basket".ShouldMapTo<CatalogController>(x => x.Basket());
		}

		[Test]
		public void checkout_should_map_to_catalog_checkout()
		{
			"~/checkout".ShouldMapTo<CatalogController>(x => x.CheckOut());
		}

		[Test]
		public void _404_should_map_to_error_notfound()
		{
			"~/404".ShouldMapTo<ErrorController>(x => x.NotFound());
		}

		[Test]
		public void ProductsByCategory_MapsToWebFormPage()
		{
			"~/Products/ByCategory".ShouldMapToPage("~/ProductsByCategory.aspx");
		}
	}
}