using System.Collections;
using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace Fase.Web.Models
{
    [PageType(Title = "Contact page")]
    [PageTypeRoute(Title = "Contacts", Route = "/contacts")]
    public class ContactPage : Page<ContactPage>
    {
        public ContactPage()
        {
            Contacts = new List<ContactPerson>();
        }

        [Region(Title = "Contact persons", ListTitle = "FirstName")]
        public IList<ContactPerson> Contacts { get; set; }
    }
}