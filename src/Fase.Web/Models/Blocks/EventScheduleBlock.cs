using Piranha.Extend;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Schedule block", Category = "Content", Icon = "fas fa-clock")]
    public class EventScheduleBlock : Block
    {
        public EventScheduleBlock()
        {
            SchedulePage = new PageField();
        }

        [Field(Title = "Schedule page")]
        public PageField SchedulePage { get; set; }
    }
}