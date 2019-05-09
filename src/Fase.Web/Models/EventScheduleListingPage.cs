using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Models;
using System.Collections.Generic;

namespace Fase.Web.Models
{
    [PageType(Title = "Event schedule listing page")]
    [PageTypeRoute(Title = "Event schedules", Route = "/eventschedules")]
    public class EventScheduleListingPage : Page<EventScheduleListingPage>
    {
        public EventScheduleListingPage()
        {
            Hero = new Hero();
            LinkButtons = new List<LinkButton>();
        }

        [Region]
        public Hero Hero { get; set; }

        [Region(ListTitle = "LinkText", Title = "Link buttons")]
        public IList<LinkButton> LinkButtons { get; set; }
    }
}
