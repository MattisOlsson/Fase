using Fase.Web.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace Fase.Web.Models
{
    [PageType(Id = "artist-listing-page", Title = "Artists page")]
    [PageTypeRoute(Route = "/artists")]
    public class ArtistListingPage : Page<ArtistListingPage>
    {
        public ArtistListingPage()
        {
            Artists = new List<Artist>();
        }

        [Field(Title = "Page heading")]
        public StringField PageHeading { get; set; }

        [Region(ListTitle = "Fullname", Title = "Artists")]
        public IList<Artist> Artists { get; set; }
    }
}
