using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;

namespace Fase.Web.Models
{
    [PageType(Title = "Start page")]
    [PageTypeRoute(Title = "Default", Route = "/")]
    public class StartPage : Page<StartPage>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartPage()
        {
            Videos = new List<Regions.Video>();
            Buttons = new List<Regions.LinkButton>();
        }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(Title = "Hero content")]
        public Regions.Hero HeroContent { get; set; }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(ListTitle = "Title", Title = "Hero videos")]
        public IList<Regions.Video> Videos { get; set; }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(ListTitle = "LinkText", Title = "Hero link buttons")]
        public IList<Regions.LinkButton> Buttons { get; set; }
    }
}