using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;

namespace Fase.Web.Models
{
    public class ContactPerson
    {
        [Field(Title = "Profile image")]
        public ImageField ProfileImage { get; set; }

        [Field(Title = "First name")]
        public StringField FirstName { get; set; }

        [Field(Title = "Last name")]
        public StringField LastName { get; set; }

        [Field]
        public StringField Email { get; set; }

        [Field]
        public StringField Phone { get; set; }
    }
}