using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using RoutingSample.Controllers;

namespace RoutingSample.Tests
{
	[TestFixture]
	public class OutboundUrlTests
	{
		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			RouteTable.Routes.Clear();
			MvcApplication.RegisterRoutes(RouteTable.Routes);
		}

		[Test]
		public void Generate_home_url()
		{
			OutBoundUrl.Of<HomeController>(x => x.Index())
				.ShouldMapToUrl("/");
		}

		[Test]
		public void Generates_products_url()
		{
			OutBoundUrl.Of<CatalogController>(x => x.Show("my-product-code"))
				.ShouldMapToUrl("/products/my-product-code");
		}
	}
}