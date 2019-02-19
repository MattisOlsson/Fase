using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using System.ComponentModel.DataAnnotations;

namespace Fase.Web.Models.Regions
{
    public class EventDetails
    {
        [Field]
        public StringField EventType { get; set; }

        [Field(Title = "Start date")]
        [Required]
        public DateField StartDate { get; set; }

        [Field(Title = "Start time")]
        public StringField StartTime { get; set; }

        [Field(Title = "End date")]
        public DateField EndDate { get; set; }

        [Field(Title = "End time")]
        public StringField EndTime { get; set; }

        [Field]
        public HtmlField Information { get; set; }

        [Field(Title = "Link to booking")]
        public StringField BookingLinkUrl { get; set; }
    }
}
