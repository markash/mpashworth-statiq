using FromZeroToHero.Models.ContentTypes;

namespace FromZeroToHero.Models.ViewModels
{
    public abstract class ViewModelBase
    {
        protected ViewModelBase(SiteMetadata metadata)
        {
            this.Author = metadata.SiteAuthor;
            this.Metadata = metadata;
        }

        public Author Author { get; set; }

        public SiteMetadata Metadata { get; set; }
    }
}