using Kentico.Kontent.Delivery.Abstractions;

namespace FromZeroToHero.Models
{
    public interface ITitleProvider
    {
        string Title { get; }

        IContentItemSystemAttributes System { get; }

        string ElementCodename { get; }
    }
}