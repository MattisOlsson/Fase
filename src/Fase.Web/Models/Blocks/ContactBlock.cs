using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Block = Piranha.Extend.Block;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Contact block", Category = "Content", Icon = "fas fa-address-book")]
    public class ContactBlock : Block
    {
        public ContactBlock()
        {
            ContactPage = new PageField();
        }

        [Field(Title = "Contact page")]
        public PageField ContactPage { get; set; }
    }
}