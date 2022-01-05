using FromZeroToHero.Models.ContentTypes;
using FromZeroToHero.Models.ViewModels;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using FromZeroToHero.Pipelines;
using System.Linq;

namespace FromZeroToHero
{
    public class ArticlePipeline : Pipeline
    {
        public ArticlePipeline(IDeliveryClient client)
        {
            Dependencies.AddRange(nameof(SiteMetadataPipeline));
            InputModules = new ModuleList
            {
                new Kontent<Article>(client)
                    .WithQuery(
                        new DepthParameter(1), 
                        new IncludeTotalCountParameter()
                    ),
                new SetDestination(Config.FromDocument((doc, ctx)  => new NormalizedPath($"articles/{doc.AsKontent<Article>().Url}.html" )))
            };

            ProcessModules = new ModuleList {
                new MergeContent(new ReadFiles(patterns: "Article.cshtml") ),
                new RenderRazor()
                    .WithModel(Config.FromDocument((document, context) =>
                        new ArticleViewModel(
                            document.AsKontent<Article>(),
                            context.Outputs.FromPipeline(nameof(SiteMetadataPipeline)).Select(x => x.AsKontent<SiteMetadata>()).FirstOrDefault()))),
                new KontentImageProcessor()
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}