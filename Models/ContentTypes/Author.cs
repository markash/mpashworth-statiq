using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Author
    {
        public Contact DefaultContact => Contacts.OfType<Contact>().FirstOrDefault();
    }
}