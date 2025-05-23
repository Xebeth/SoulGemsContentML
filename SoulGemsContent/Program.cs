using MagicLoaderGenerator.Localization.Providers;
using MagicLoaderGenerator.Filesystem.Generators;
using Microsoft.Extensions.Configuration;
using MagicLoaderGenerator;
using SampleModML;

var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("config.json", optional: false);
var appConfig = new SoulGemsContentConfig(builder.Build());
var localization = new JsonLocalizationProvider(appConfig);
var mod = new MagicLoaderMod(localization, appConfig);

mod.Generate(new ZipOutputGenerator(appConfig), new SoulGemSuffixTransform(localization, appConfig));
