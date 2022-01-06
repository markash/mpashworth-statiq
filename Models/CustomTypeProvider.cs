using FromZeroToHero.Models.ContentTypes;
using Kentico.Kontent.Delivery.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FromZeroToHero.Models
{
    public class CustomTypeProvider : ITypeProvider
    {
        private static readonly Dictionary<Type, string> _codenames = new Dictionary<Type, string>
        {
            {typeof(Article), "article"},
            {typeof(Author), "author"},
            {typeof(Contact), "contact"},
            {typeof(Hero), "hero"},
            {typeof(HomePage), "home_page"},
            {typeof(LandingPageExampleContentType), "landing_page_example_content_type"},
            {typeof(Page), "page"},
            {typeof(ProductExampleContentType), "product_example_content_type"},
            {typeof(SiteMetadata), "site_metadata"}
        };

        public Type GetType(string contentType)
        {
            return _codenames.Keys.FirstOrDefault(type => GetCodename(type).Equals(contentType));
        }

        public string GetCodename(Type contentType)
        {
            return _codenames.TryGetValue(contentType, out var codename) ? codename : null;
        }
    }
}