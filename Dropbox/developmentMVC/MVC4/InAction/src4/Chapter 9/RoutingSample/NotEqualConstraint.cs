using System;
using System.Web;
using System.Web.Routing;

namespace RoutingSample
{
	public class NotEqualConstraint : IRouteConstraint
	{
		private string _input;

		public NotEqualConstraint(string input)
		{
			_input = input;
		}

		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
		{
			object matchingValue;

			if(values.TryGetValue(parameterName, out matchingValue))
			{
				if (_input.Equals((string)matchingValue, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}

			return true;
		}
	}
}