using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Event listing page")]
    [PageTypeRoute(Title = "Events", Route = "/events")]
    public class EventListingPage : Page<EventListingPage>
    {
    }
}
