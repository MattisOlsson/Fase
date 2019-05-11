using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using System.ComponentModel.DataAnnotations;
using Fase.Web.Configuration;

namespace Fase.Web.Models.Regions
{
    public class EventDetails
    {
        [Field(Title = "Flyer image")]
        public ImageField FlyerImage { get; set; }

        [Field]
        public StringField EventType { get; set; }

        [Field(Title = "Start date")]
        public DateField StartDate { get; set; }

        [Field(Title = "Start time")]
        [UIHint(FaseUiHint.EventTime)]
        public StringField StartTime { get; set; }

        [Field(Title = "End date")]
        public DateField EndDate { get; set; }

        [Field(Title = "End time")]
        [UIHint(FaseUiHint.EventTime)]
        public StringField EndTime { get; set; }

        [Field]
        public HtmlField Information { get; set; }

        [Field(Title = "Link to booking")]
        public StringField BookingLinkUrl { get; set; }
    }
}
