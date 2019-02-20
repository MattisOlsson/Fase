using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class ArticleImage
    {
        [Field]
        public ImageField MainImage { get; set; }

        public bool ShouldRender()
        {
            return false;
        }
    }
}
