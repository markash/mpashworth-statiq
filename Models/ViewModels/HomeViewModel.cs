using System.Linq;
using FromZeroToHero.Models.ContentTypes;
using System.Collections.Generic;

namespace FromZeroToHero.Models.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Hero Hero { get; set; }
        public List<Article> Articles { get; set; }
        public List<Page> Subpages { get; set; }
        public ITitleProvider TitleProvider { get; }

        public HomeViewModel(HomePage homePage, List<Article> articles, SiteMetadata metadata) : base(metadata)
        {
            this.Hero = homePage.Hero.OfType<Hero>().FirstOrDefault();
            this.Articles = articles;
            this.Subpages = homePage.Subpages.OfType<Page>().ToList();
        }
    }
}