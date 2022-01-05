using FromZeroToHero.Models.ContentTypes;

namespace FromZeroToHero.Models.ViewModels
{
    public class ArticleViewModel : ViewModelBase
    {
        public Article Article { get; private set; }

        public ArticleViewModel(Article article, SiteMetadata metadata) : base(metadata)
        {
            Article = article;
        }
    }
}
