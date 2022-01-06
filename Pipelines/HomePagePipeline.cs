using FromZeroToHero.Models.ContentTypes;
using Kentico.Kontent.Delivery.Abstractions;

namespace FromZeroToHero.Pipelines
{
    public class HomePagePipeline : LoadDataPipeLine<HomePage>
    {
        public HomePagePipeline(IDeliveryClient deliveryClient) : base(deliveryClient)
        {
        }
    }
}