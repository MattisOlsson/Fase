using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Standard page")]
    public class StandardPage  : Page<StandardPage>
    {
        public StandardPage()
        {
            Hero = new SimpleHero();
        }

        [Region]
        public SimpleHero Hero { get; set; }
    }
}