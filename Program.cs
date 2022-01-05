using System.Threading.Tasks;
using FromZeroToHero.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace FromZeroToHero
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>

            await Bootstrapper
                .Factory
                .CreateDefault(args)
                //.BuildConfiguration(cfg => cfg.AddUserSecrets<Program>())
                .ConfigureServices((services, settings) =>
                {
                    services.AddSingleton<ITypeProvider, CustomTypeProvider>();
                    services.AddDeliveryClient((IConfiguration)settings);
                })
                .AddHostingCommands()
                .RunAsync();
    }
}