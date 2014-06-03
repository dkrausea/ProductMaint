using System;
using System.Collections.Generic;
using System.Linq;
using SmartBindersExample.Models;

namespace SmartBindersExample.Helpers
{
	public static class ServiceLocator
	{
		public static object Resolve(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IRepository<>))
			{
				return Activator.CreateInstance(typeof(ProfileRepository));
			}
			return null;
        }

		public static IEnumerable<T> ResolveMany<T>()
		{
		    return Enumerable.Empty<T>();
		}
		
		public static IEnumerable<object> ResolveMany(Type type)
		{
		    return Enumerable.Empty<object>();
		}
		
		public static object Resolve<T>()
		{
			return null;
		}
	}
}