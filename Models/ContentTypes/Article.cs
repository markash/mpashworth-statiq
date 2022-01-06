using Kentico.Kontent.Delivery.Abstractions;
using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Article
    {
        public IAsset TitleImage => Image?.OfType<IAsset>().FirstOrDefault();
        public Author PrimaryAuthor => Author?.OfType<Author>().FirstOrDefault();
    }
}