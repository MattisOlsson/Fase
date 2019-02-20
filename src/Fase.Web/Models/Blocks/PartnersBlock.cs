using Piranha.Extend;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Partners block", Category = "Content", Icon = "fas fa-handshake")]
    public class PartnersBlock : Block
    {
        public PartnersBlock()
        {
            PartnersPage = new PageField();
        }

        [Field]
        public PageField PartnersPage { get; set; }
    }
}