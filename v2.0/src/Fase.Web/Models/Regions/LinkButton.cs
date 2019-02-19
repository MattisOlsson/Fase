using Fase.Web.Models.SelectFieldEnums;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class LinkButton
    {
        public LinkButton()
        {
            CssClass = new SelectField<ButtonCssClass>
            {
                Value = ButtonCssClass.Standard
            };
        }

        [Field(Title = "Page link")]
        public PageField Page { get; set; }

        [Field(Title = "External link")]
        public StringField ExternalLink { get; set; }

        [Field(Title = "Link text")]
        public StringField LinkText { get; set; }

        [Field(Title = "Button style")]
        public SelectField<ButtonCssClass> CssClass { get; set; }

        public string GetLinkUrl()
        {
            if (Page.HasValue)
            {
                return Page.Page.Permalink;
            }

            return ExternalLink;
        }

        public string GetCssClass()
        {
            switch (CssClass?.Value)
            {
                case ButtonCssClass.Primary:
                    return "button button--primary";
                case ButtonCssClass.StandardInvert:
                    return "button button--invert";
                case ButtonCssClass.PrimaryInvert:
                    return "button button--primary button--primary-invert";
                default:
                    return "button";
            }
        }
    }
}
