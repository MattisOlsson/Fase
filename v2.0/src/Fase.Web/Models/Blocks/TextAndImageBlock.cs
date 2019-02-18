using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using System.ComponentModel.DataAnnotations;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Text block with image", Category = "Content", Icon = "fas fa-newspaper")]
    public class TextAndImageBlock : Block
    {
        [Field]
        public StringField Heading { get; set; }

        [Field(Title = "Sub heading")]
        [Display(Name = "Sub heading")]
        public StringField SubHeading { get; set; }

        [Field]
        public HtmlField Text { get; set; }

        [Field]
        public ImageField Image { get; set; }

        [Field(Title = "Block style")]
        [Display(Name = "Block style")]
        public SelectField<TextBlockCssClass> CssClass { get; set; }

        public string GetCssClass()
        {
            switch (CssClass?.Value)
            {
                case TextBlockCssClass.Grey:
                    return "text-block text-block--grey";
                default:
                    return "text-block";
            }
        }
    }
}
