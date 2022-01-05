using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;
using System.Linq;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Article
    {
        public IAsset TitleImage => Image?.OfType<IAsset>().FirstOrDefault();
    }
}