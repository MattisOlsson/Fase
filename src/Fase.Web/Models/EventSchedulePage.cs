using System.Collections.Generic;
using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Event schedule page")]
    [PageTypeRoute(Title = "Event schedule", Route = "/eventschedule")]
    public class EventSchedulePage : Page<EventSchedulePage>
    {
        public EventSchedulePage()
        {
            Hero = new Hero
            {
                CssClass = new SelectField<HeroCssClass>
                {
                    Value = HeroCssClass.Content
                }
            };

            Items = new List<ScheduleItem>();
        }

        [Region(Title = "Hero")]
        public Hero Hero { get; set; }

        [Region(Title = "Schedule", ListTitle = "Heading")]
        public IList<ScheduleItem> Items { get; set; }
    }
}