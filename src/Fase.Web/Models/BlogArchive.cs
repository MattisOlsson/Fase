using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive  : ArchivePage<BlogArchive>
    {
        /// <summary>
        /// Gets/sets the archive heading.
        /// </summary>
        [Region]
        public Regions.Heading Heading { get; set; }
    }
}