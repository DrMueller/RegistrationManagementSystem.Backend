using AutoMapper;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.DataModels.Adapters.Profiles
{
    public class EventRegistrationDataModelProfile : Profile
    {
        public EventRegistrationDataModelProfile()
        {
            CreateMap<EventRegistrationDataModel, EventRegistration>()
                .ForMember(d => d.EmailId, c => c.MapFrom(f => f.EmailId))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.IndividualId, c => c.MapFrom(f => f.IndividualId));
        }
    }
}