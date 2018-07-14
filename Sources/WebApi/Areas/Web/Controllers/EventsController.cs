using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mmu.Rms.WebApi.Areas.DataAccess.Repositories;
using Mmu.Rms.WebApi.Areas.Domain.Factories;
using Mmu.Rms.WebApi.Areas.Web.Dtos;

namespace Mmu.Rms.WebApi.Areas.Web.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventFactory _eventFactory;

        private readonly IEventRegistrationFactory _eventRegistrationFactory;

        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;

        public EventsController(
            IEventFactory eventFactory,
            IEventRegistrationFactory eventRegistrationFactory,
            IEventRepository eventRepository,
            IMapper mapper)
        {
            _eventFactory = eventFactory;
            _eventRegistrationFactory = eventRegistrationFactory;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventsAsync()
        {
            var allEvents = await _eventRepository.LoadAllAsync();
            var dtos = _mapper.Map<List<EventDto>>(allEvents);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(string id)
        {
            var allEvents = await _eventRepository.LoadByIdAsync(id);
            var dto = _mapper.Map<EventDto>(allEvents);
            return Ok(dto);
        }

        //public IActionResult Test()
        //{
        //    using (var client = new ImapClient("imap-mail.outlook.com", 993, "MatthiasM@live.de", "joker1joker2", ssl: true))
        //    {
        //        var tra = client.ListMailboxes();
        //        var tra2 = tra.FirstOrDefault(f => f.Contains("Wichtiges"));

        //        var mailboxInfo = client.GetMailboxInfo(tra2);
        //        while (true)
        //        {
        //            var guids = client.Search(SearchCondition.Subject("Test"));
        //            var messages = client.GetMessages(guids);
        //        }
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> SaveEventAsync([FromBody] EventDto dto)
        {
            var eventRegistrations = dto.Registrations?.Select(
                    f => _eventRegistrationFactory.Create(f.IndividualId, f.EmailId, f.Id))
                .ToList();

            var newEvent = _eventFactory.Create(
                dto.EventName,
                eventRegistrations);

            var returnedEvent = await _eventRepository.SaveAsync(newEvent);
            var result = _mapper.Map<EventDto>(returnedEvent);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAsync([FromRoute] string id)
        {
            await _eventRepository.DeleteAsync(id);
            return Ok();
        }
    }
}