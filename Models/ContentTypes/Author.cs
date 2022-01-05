using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;
using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Author
    {
        public Contact DefaultContact => Contacts.OfType<Contact>().FirstOrDefault();
    }
}