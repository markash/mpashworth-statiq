using Kentico.Kontent.Delivery.Abstractions;
using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Contact
    {
        public IAsset ProfileImage => Image?.OfType<IAsset>().FirstOrDefault();
    }
}