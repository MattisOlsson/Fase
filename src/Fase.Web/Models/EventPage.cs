using System;
using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Event page")]
    [PageTypeRoute(Title = "Event", Route = "/event")]
    public class EventPage : Page<EventPage>
    {
        public EventPage()
        {
            Hero = new Hero
            {
                CssClass = new SelectField<HeroCssClass>
                {
                    Value = HeroCssClass.Content,
                }
            };

            Details = new EventDetails();
        }

        [Region]
        public Hero Hero { get; set; }

        [Region(Title = "Event details")]
        public EventDetails Details { get; set; }

        public DateTime? StartDate => Details.StartDate.Value;

        public DateTime? EndDate => Details.EndDate.Value ?? Details.StartDate.Value;
    }
}
