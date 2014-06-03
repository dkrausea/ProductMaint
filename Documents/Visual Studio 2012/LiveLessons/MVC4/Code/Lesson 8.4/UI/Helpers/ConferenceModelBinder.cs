using System;
using System.Web.Mvc;
using CodeCampServerLite.UI.Domain;
using CodeCampServerLite.UI.Infrastructure;

namespace CodeCampServerLite.UI.Helpers
{
    public class ConferenceModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType != typeof(Conference))
            {
                return null;
            }

            return DependencyResolver.Current.GetService<ConferenceModelBinder>();
        }
    }

    public class ConferenceModelBinder : IModelBinder
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceModelBinder(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string name = (string)bindingContext.ValueProvider.GetValue(bindingContext.ModelName).RawValue;

            return _conferenceRepository.FindByName(name);
        }
    }
}