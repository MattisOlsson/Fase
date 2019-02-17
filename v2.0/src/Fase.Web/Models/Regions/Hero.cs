using System.Collections;
using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Regions
{
    public class Hero
    {
        [Field]
        public ImageField Logo { get; set; }

        [Field]
        public TextField Heading { get; set; }

        [Field]
        public HtmlField Text { get; set; }
    }
}