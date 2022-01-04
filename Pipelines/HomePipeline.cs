using FromZeroToHero.Models.ContentTypes;
using FromZeroToHero.Models.ViewModels;
using FromZeroToHero.Pipelines;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using System.Linq;

namespace FromZeroToHero
{
    public class HomePipeline : Pipeline
    {
        public HomePipeline(IDeliveryClient client)
        {
            Dependencies.AddRange(nameof(HomePagePipeline), nameof(SiteMetadataPipeline));
            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(Dependencies.ToArray()),
                new SetDestination(Config.FromDocument((doc, ctx) => Filename(doc))),
                new MergeContent(
                    new ReadFiles(patterns: "Index.cshtml")
                ),
                new RenderRazor()
                    .WithModel(Config.FromDocument((document, context) =>
                    {
                        var homePage = context.Outputs
                            .FromPipeline(nameof(HomePagePipeline))
                            .Select(x => x.AsKontent<HomePage>())
                            .FirstOrDefault();

                        System.Console.WriteLine(homePage);

                        

                        var metadata = context.Outputs
                            .FromPipeline(nameof(SiteMetadataPipeline))
                            .Select(x => x.AsKontent<SiteMetadata>())
                            .FirstOrDefault();

                        System.Console.WriteLine($"Blah {metadata.Title}");
                        System.Console.WriteLine(metadata?.Title);

                        return new HomeViewModel(homePage, metadata);
                    }
                    ))
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }

        private static NormalizedPath Filename(IDocument document)
        {
            var index = document.GetInt(Keys.Index);

            return new NormalizedPath($"{(index > 1 ? $"page/{index}/" : "")}index.html");
        }
    }
}