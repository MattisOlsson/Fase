using Fase.Web.Models.SelectFieldEnums;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class Hero
    {
        [Field(Title = "Background image")]
        public ImageField BackgroundImage { get; set; }

        [Field]
        public ImageField Logo { get; set; }

        [Field]
        public TextField Heading { get; set; }

        [Field]
        public HtmlField Text { get; set; }

        [Field]
        public SelectField<HeroCssClass> CssClass { get; set; }

        public string GetCssClass()
        {
            switch (CssClass?.Value)
            {
                case HeroCssClass.Medium:
                    return "hero hero--medium";
                case HeroCssClass.Content:
                    return "hero hero--static";
                case HeroCssClass.Video:
                    return "hero hero--video";
                default:
                    return "hero hero--small";
            }
        }
    }
}