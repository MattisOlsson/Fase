using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PostType(Title = "Blog post")]
    public class BlogPost  : Post<BlogPost>
    {
        /// <summary>
        /// Gets/sets the post heading.
        /// </summary>
        [Region]
        public Regions.Heading Heading { get; set; }
    }
}