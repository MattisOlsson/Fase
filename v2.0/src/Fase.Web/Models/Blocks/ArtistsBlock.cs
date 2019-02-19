using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Artists block", Category = "Content", Icon = "fas fa-music")]
    public class ArtistsBlock : TextAndImageBlock
    {
        public ArtistsBlock()
        {
            ArtistsPage = new PageField();
        }

        [Field]
        public PageField ArtistsPage { get; set; }
    }
}
