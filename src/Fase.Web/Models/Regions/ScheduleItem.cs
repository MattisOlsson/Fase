using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class ScheduleItem
    {
        [Field(Title = "Image")]
        public ImageField ListingImage { get; set; }

        [Field]
        public StringField Heading { get; set; }

        [Field]
        public StringField Time { get; set; }

        [Field]
        public StringField Location { get; set; }

        [Field]
        public TextField Intro { get; set; }

        [Field]
        public HtmlField Description { get; set; }
    }
}
