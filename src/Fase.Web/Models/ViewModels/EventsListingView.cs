using System.Collections.Generic;

namespace Fase.Web.Models.ViewModels
{
    public class EventsListingView
    {
        public EventsListingView(EventListingPage page)
        {
            Page = page;
        }

        public readonly EventListingPage Page;

        public IEnumerable<EventPage> UpcomingEvents { get; set; }
        public IEnumerable<EventPage> EarlierEvents { get; set; }
    }
}