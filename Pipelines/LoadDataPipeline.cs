using Kentico.Kontent.Delivery.Abstractions;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;

namespace FromZeroToHero.Pipelines
{
    public abstract class LoadDataPipeLine<TContentModel> : Pipeline where TContentModel : class
    {
        public LoadDataPipeLine(IDeliveryClient deliveryClient, params IQueryParameter[] parameters)
        {
            InputModules = new ModuleList{
                new Kontent<TContentModel>(deliveryClient).WithQuery(parameters)
            };
        }
    }
}