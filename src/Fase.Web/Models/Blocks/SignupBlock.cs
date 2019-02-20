using System.ComponentModel.DataAnnotations;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Fase.Web.Models.Blocks
{
    [BlockType(Name = "Signup block", Category = "Content", Icon = "fas fa-user-plus")]
    public class SignupBlock : Block
    {
        [Field]
        public StringField Heading { get; set; }

        [Field]
        [Display(Name = "Email subject")]
        public StringField EmailSubject { get; set; }
    }
}