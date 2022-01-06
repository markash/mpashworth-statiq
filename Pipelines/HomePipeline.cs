using FromZeroToHero.Models.ContentTypes;
using FromZeroToHero.Models.ViewModels;
using FromZeroToHero.Pipelines;
using Kentico.Kontent.Delivery.Abstractions;
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
            Dependencies.AddRange(nameof(ArticlePipeline), nameof(HomePagePipeline), nameof(SiteMetadataPipeline));
            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(HomePagePipeline)),
                new SetDestination(Config.FromDocument((doc, ctx) => Filename(doc))),
                new MergeContent(
                    new ReadFiles(patterns: "Index.cshtml")
                ),
                new RenderRazor()
                    .WithModel(Config.FromDocument((document, context) =>
                    {
                        System.Console.WriteLine($"Text {document}");

                        var homePage = context.Outputs
                            .FromPipeline(nameof(HomePagePipeline))
                            .Select(x => x.AsKontent<HomePage>())
                            .FirstOrDefault();

                        var articles = context.Outputs
                            .FromPipeline(nameof(ArticlePipeline))
                            .Select(x => x.AsKontent<Article>())
                            .ToList();

                        var metadata = context.Outputs
                            .FromPipeline(nameof(SiteMetadataPipeline))
                            .Select(x => x.AsKontent<SiteMetadata>())
                            .FirstOrDefault();

                        return new HomeViewModel(homePage, articles, metadata);
                    }
                    )),
                new KontentImageProcessor()
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }

        private static NormalizedPath Filename(IDocument document)
        {
            System.Console.WriteLine(document.Id);

            var index = document.GetInt(Keys.Index);

            return new NormalizedPath($"{(index > 1 ? $"page/{index}/" : "")}index.html");
        }
    }
}