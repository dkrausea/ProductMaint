using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace ControllerFactoryExamples
{
	public class StructureMapControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType) 
		{
			if(controllerType == null)
			{
				throw new HttpException(404, "Controller not found.");
			}

			return ObjectFactory.GetInstance(controllerType) as IController;
		}
	}
}