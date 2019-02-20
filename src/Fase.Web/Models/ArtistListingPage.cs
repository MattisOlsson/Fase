using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace Fase.Web.Models
{
    [PageType(Title = "Artists page")]
    [PageTypeRoute(Title = "Artists", Route = "/artists")]
    public class ArtistListingPage : Page<ArtistListingPage>
    {
        public ArtistListingPage()
        {
            Hero = new Hero();
            Artists = new List<Artist>();
            LinkButtons = new List<LinkButton>();
        }

        [Region]
        public Hero Hero { get; set; }

        [Field(Title = "Page heading")]
        public StringField PageHeading { get; set; }

        [Region(ListTitle = "Firstname", Title = "Artists")]
        public IList<Artist> Artists { get; set; }

        [Region(ListTitle = "LinkText", Title = "Link buttons")]
        public IList<LinkButton> LinkButtons { get; set; }
    }
}
