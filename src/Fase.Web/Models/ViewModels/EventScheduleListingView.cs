using System.Collections.Generic;
using Fase.Web.Models.Regions;
using Piranha.Extend;

namespace Fase.Web.Models.ViewModels
{
    public class EventScheduleListingView
    {
        public EventScheduleListingView()
        {
            Schedules = new List<EventSchedulePage>();
        }

        public string Title { get; set; }
        public Hero Hero { get; set; }
        public IList<Block> Blocks { get; set; }
        public IEnumerable<EventSchedulePage> Schedules { get; set; }
    }
}