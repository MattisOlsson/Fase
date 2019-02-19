using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using System.ComponentModel.DataAnnotations;

namespace Fase.Web.Models.Regions
{
    public class Artist
    {
        [Field(Title = "Profile image")]
        [Required]
        public ImageField ProfileImage { get; set; }

        [Field(Title = "First name")]
        [Required]
        public StringField Firstname { get; set; }

        [Field(Title = "Last name")]
        [Required]
        public StringField Lastname { get; set; }

        [Field]
        [Required]
        public HtmlField Presentation { get; set; }

        [Field(Title = "Optional website")]
        public StringField WebsiteUrl { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
