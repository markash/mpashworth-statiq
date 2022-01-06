using Kontent.Statiq;
using System.Linq;
using Statiq.Common;
using Statiq.Core;

namespace FromZeroToHero.Pipelines
{
    public class DownloadImagesPipeline : Pipeline
    {
        public DownloadImagesPipeline()
        {
            Dependencies.AddRange(nameof(ArticlePipeline), nameof(HomePipeline));
            PostProcessModules = new ModuleList(
                new ReplaceDocuments(Dependencies.ToArray()),
                new KontentDownloadImages()
            );
            OutputModules = new ModuleList(
                new WriteFiles()
            );
        }
    }
}
