using Fase.Web.Models.Regions;
using Fase.Web.Models.SelectFieldEnums;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Standard page")]
    public class StandardPage  : Page<StandardPage>
    {
        public StandardPage()
        {
            Hero = new Hero
            {
                CssClass = new SelectField<HeroCssClass>
                {
                    Value = HeroCssClass.Small
                }
            };
        }

        [Region(Title = "Hero")]
        public Hero Hero { get; set; }
    }
}