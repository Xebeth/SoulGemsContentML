using MagicLoaderGenerator.Filesystem.Abstractions;
using MagicLoaderGenerator.Localization.Providers;
using MagicLoaderGenerator.Filesystem.Generators;
using Microsoft.Extensions.Configuration;
using MagicLoaderGenerator;
using SoulGemsContent;

var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("config.json", optional: false);
var variants = new Dictionary<string, IMagicLoaderFileTransform?>();
var appConfig = new SoulGemsContentConfig(builder.Build());
var localization = new JsonLocalizationProvider(appConfig);
var mod = new MagicLoaderMod(localization, appConfig);

foreach (var (variant, prefix) in appConfig.Prefixes)
{
    variants.Add(variant, new SoulGemSuffixTransform(localization, appConfig, prefix));
}

var outputDir = mod.Generate(new ZipOutputGenerator(appConfig), variants);

#if DEBUG
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
    UseShellExecute = true,
    FileName = outputDir,
    Verb = "open"
});
#endif
