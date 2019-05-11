using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class EventListing
    {
        public EventListing()
        {
            UpcomingEventsHeading = "Kommande";
            EarlierEventsHeading = "Tidigare";
        }

        [Field(Title = "Upcoming events heading")]
        public StringField UpcomingEventsHeading { get; set; }

        [Field(Title = "Upcoming events heading")]
        public StringField EarlierEventsHeading { get; set; }

    }
}