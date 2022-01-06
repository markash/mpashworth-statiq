using Statiq.Common;
using Statiq.Core;

namespace FromZeroToHero.Pipelines
{
    public class CopyAssetsPipeline : Pipeline
    {
        public CopyAssetsPipeline()
        {
            InputModules = new ModuleList
            {
                new CopyFiles("./assets/{css,fonts,js,img}/**/*", "./*.{png,ico,webmanifest}")
            };
        }
    }
}