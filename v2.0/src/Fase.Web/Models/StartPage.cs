using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;
using System.Collections.Generic;
using Fase.Web.Models.Regions;

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
            Videos = new List<Video>();
            Buttons = new List<LinkButton>();
            HeroContent = new Hero
            {
                CssClass = new SelectField<HeroCssClass>
                {
                    Value = HeroCssClass.Video
                }
            };
        }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(Title = "Hero content")]
        public Hero HeroContent { get; set; }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(ListTitle = "Title", Title = "Hero videos")]
        public IList<Video> Videos { get; set; }

        /// <summary>
        /// Gets/sets the page heading.
        /// </summary>
        [Region(ListTitle = "LinkText", Title = "Hero link buttons")]
        public IList<LinkButton> Buttons { get; set; }
    }
}