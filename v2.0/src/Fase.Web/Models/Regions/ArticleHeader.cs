using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class ArticleImage
    {
        [Field]
        public ImageField Image { get; set; }

        public bool ShouldRender()
        {
            return Image.HasValue;
        }
    }
}
