using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models.Regions
{
    public class SimpleHero
    {
        /// <summary>
        /// Gets/sets the optional primary image.
        /// </summary>
        [Field(Title = "Background image")]
        public ImageField BackgroundImage { get; set; }

        /// <summary>
        /// Gets/sets the optional heading.
        /// </summary>
        [Field]
        public StringField Heading { get; set; }
    }
}