using AutoMapper;
using CodeCampServerLite.UI.Domain;
using CodeCampServerLite.UI.Models;

namespace CodeCampServerLite.UI.Infrastructure.AutoMapper
{
    public static class AutoMapperBootstrapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ViewModelProfile>();
                cfg.AddProfile<EditModelProfile>();
            });
        }
    }

    public class ViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Conference, ConferenceListModel>();
        }
    }

    public class EditModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Conference, ConferenceEditModel>();
            CreateMap<Attendee, ConferenceEditModel.AttendeeEditModel>();
        }
    }
}