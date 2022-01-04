using Kentico.Kontent.Delivery.Abstractions;
using FromZeroToHero.Models.ContentTypes;

namespace FromZeroToHero.Pipelines
{
    public class HomePagePipeline : LoadDataPipeLine<HomePage>
    {
        public HomePagePipeline(IDeliveryClient deliveryClient) : base(deliveryClient)
        {
        }
    }
}