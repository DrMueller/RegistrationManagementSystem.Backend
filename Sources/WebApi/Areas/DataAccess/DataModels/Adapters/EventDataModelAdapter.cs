using System.Linq;
using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Rms.WebApi.Areas.Domain.Factories;
using Mmu.Rms.WebApi.Areas.Domain.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.DataModels.Adapters
{
    public class EventDataModelAdapter : IDataModelAdapter<EventDataModel, Event>
    {
        private readonly IEventFactory _eventFactory;

        private readonly IEventRegistrationFactory _eventRegistrationFactory;

        private readonly IMapper _mapper;

        public EventDataModelAdapter(
            IEventFactory eventFactory,
            IEventRegistrationFactory eventRegistrationFactory,
            IMapper mapper)
        {
            _eventFactory = eventFactory;
            _eventRegistrationFactory = eventRegistrationFactory;
            _mapper = mapper;
        }

        public Event Adapt(EventDataModel dataModel)
        {
            var eventRegistrations = dataModel.Registrations.Select(
                    f => _eventRegistrationFactory.Create(f.IndividualId, f.EmailId, f.Id))
                .ToList();

            return _eventFactory.Create(dataModel.EventName, eventRegistrations, dataModel.Id);
        }

        public EventDataModel Adapt(Event aggregateRoot) => _mapper.Map<EventDataModel>(aggregateRoot);
    }
}