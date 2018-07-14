using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Rms.WebApi.Areas.DataAccess.DataModels
{
    public class EventRegistrationDataModel : DataModelBase
    {
        public string EmailId { get; set; }
        public string IndividualId { get; set; }
    }
}