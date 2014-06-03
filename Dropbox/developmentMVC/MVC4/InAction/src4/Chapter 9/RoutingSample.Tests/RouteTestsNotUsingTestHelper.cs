using System.Web;
using System.Web.Routing;
using NUnit.Framework;
using Rhino.Mocks;

namespace RoutingSample.Tests
{
	[TestFixture]
	public class NotUsingTestHelper
	{
		[Test]
		public void root_matches_home_controller_index_action()
		{
			const string url = "~/";

			var request = MockRepository.GenerateStub<HttpRequestBase>();
			request.Stub(x => x.AppRelativeCurrentExecutionFilePath)
				.Return(url).Repeat.Any();

			request.Stub(x => x.PathInfo)
				.Return(string.Empty).Repeat.Any();

			var context = MockRepository
				.GenerateStub<HttpContextBase>();

			context.Stub(x => x.Request)
				.Return(request).Repeat.Any();

			RouteTable.Routes.Clear();
			MvcApplication.RegisterRoutes(RouteTable.Routes);
			
			var routeData = RouteTable.Routes.GetRouteData(context);
			Assert.That(routeData.Values["controller"], Is.EqualTo("Home"));
			Assert.That(routeData.Values["action"], Is.EqualTo("Index"));
		}
	}
}