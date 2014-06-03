using System.Web.Mvc;
using CodeCampServerLite.UI.Helpers;

namespace CodeCampServerLite.UI.Controllers
{
    public abstract class DefaultController : Controller
    {
        protected XmlResult<T> Xml<T>(T toSerialize)
        {
            return new XmlResult<T>
            {
                ModelToSerialize = toSerialize
            };
        }
    }
}