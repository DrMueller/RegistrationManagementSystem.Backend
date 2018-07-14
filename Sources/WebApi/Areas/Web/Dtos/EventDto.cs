using System.Collections.Generic;

namespace Mmu.Rms.WebApi.Areas.Web.Dtos
{
    public class EventDto
    {
        public string EventName { get; set; }
        public string Id { get; set; }
        public List<EventRegistrationDto> Registrations { get; set; }
    }
}