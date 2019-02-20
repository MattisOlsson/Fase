using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace Fase.Web.Models.Regions
{
    public class Video
    {
        [Field]
        public StringField Title { get; set; }

        [Field(Title = "Video")]
        public VideoField VideoFile { get; set; }
    }
}