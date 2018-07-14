using AutoMapper;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.DataModels.Adapters.Profiles
{
    public class EventDataModelProfile : Profile
    {
        public EventDataModelProfile()
        {
            CreateMap<EventDataModel, Event>()
                .ForMember(d => d.EventName, c => c.MapFrom(f => f.EventName))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.Registrations, c => c.MapFrom(f => f.Registrations));
        }
    }
}