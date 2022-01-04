using FromZeroToHero.Models.ContentTypes;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;

namespace FromZeroToHero.Pipelines
{
    public class SiteMetadataPipeline : LoadDataPipeLine<SiteMetadata>
    {
        public SiteMetadataPipeline(IDeliveryClient deliveryClient) : base(deliveryClient, new DepthParameter(2))
        {
        }
    }
}