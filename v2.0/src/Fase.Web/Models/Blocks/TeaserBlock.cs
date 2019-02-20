using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Teaser block", Category = "Content", Icon = "fas fa-newspaper")]
    public class TeaserBlock : Block
    {
        [Field]
        public ImageField Image { get; set; }

        [Field]
        public StringField Heading { get; set; }

        [Field]
        public HtmlField Text { get; set; }
    }
}
