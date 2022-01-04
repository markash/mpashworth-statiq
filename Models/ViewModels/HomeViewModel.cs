using System.Linq;
using FromZeroToHero.Models.ContentTypes;
using System.Collections.Generic;

namespace FromZeroToHero.Models.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Hero Hero { get; set; }

        public List<Page> Subpages { get; set; }

        public ITitleProvider TitleProvider { get; }

        public HomeViewModel(HomePage homePage, SiteMetadata metadata) : base(metadata)
        {
            this.Hero = homePage.Hero.OfType<Hero>().FirstOrDefault();
            this.Subpages = homePage.Subpages.OfType<Page>().ToList();
        }
    }
}