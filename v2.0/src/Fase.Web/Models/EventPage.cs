using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Id = "event-page", Title = "Event page")]
    public class EventPage : Post<EventPage>
    {
        [Field]
        public DateField StartDate { get; set; }

        [Field]
        public DateField EndDate { get; set; }
    }
}
