using System.Collections.Generic;
using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Partners page")]
    [PageTypeRoute(Title = "Partners", Route = "/partners")]
    public class PartnersPage  : Page<PartnersPage>
    {
        public PartnersPage()
        {
            Partners = new List<Partner>();
            Hero = new SimpleHero();
        }

        [Region]
        public SimpleHero Hero { get; set; }

        [Region(ListTitle = "Name", Title = "Partners")]
        public IList<Partner> Partners { get; set; }
    }
}