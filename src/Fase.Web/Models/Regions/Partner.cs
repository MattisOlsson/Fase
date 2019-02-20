using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class Partner
    {
        [Field]
        public StringField Name { get; set; }

        [Field]
        public ImageField Logo { get; set; }

        [Field(Title = "Website")]
        public StringField WebsiteUrl { get; set; }
    }
}