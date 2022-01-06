using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{

    public partial class SiteMetadata
    {
        public Author SiteAuthor => Authors.OfType<Author>().First();
    }
}