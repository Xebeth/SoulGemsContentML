using MagicLoaderGenerator.Localization.Abstractions;
using MagicLoaderGenerator.Localization.Transforms;
using MagicLoaderGenerator.Localization;
using MagicLoaderGenerator.Filesystem;

namespace SampleModML;

public class SoulGemSuffixTransform(ILocalizationProvider localization, SoulGemsContentConfig appConfig):
    TranslateFileTransform(localization)
{
    private readonly Dictionary<string, string> _soulLevels = appConfig.SoulLevels;
    private readonly ILocalizationProvider _localization = localization;
    // The Filled string is not present in localization files on its own
    private readonly Dictionary<string, string> _filledTranslations = new() {
        { LanguagesEnum.German, "Gefüllt" },
        { LanguagesEnum.English, "Filled" },
        { LanguagesEnum.Spanish, "Completada" },
        { LanguagesEnum.French, "Remplie" },
        { LanguagesEnum.Italian, "Riempito" },
        { LanguagesEnum.Japanese, "満たされた" },
        { LanguagesEnum.Polish, "Wypełniony" },
        { LanguagesEnum.Portuguese, "Cheia" },
        { LanguagesEnum.Russian, "Заполненный" },
        { LanguagesEnum.SimplifiedChinese, "充满"}
    };
    // other soul levels are found in the ST_HardcodedContent but MagicLoader doesn't expand them
    private const string HardcodedSoulLevelPrefix = "LOC_HC_TESSoulGem_sSoulLevelName";

    public override MagicLoaderFile Transform(string language, MagicLoaderFile magicLoaderFile)
    {
        // create edit entries for filled gems
        if (magicLoaderFile.FullNamesEditEntries.Count > 0)
        {
            // create a dictionary to hold the result of the transformations
            magicLoaderFile.FullNames_Edit ??= new Dictionary<string, string>();

            foreach (var entry in magicLoaderFile.FullNamesEditEntries)
            {
                // format each entry found in the MagicLoader file
                magicLoaderFile.FullNames_Edit[entry] = FormatLine(language, entry);
            }
        }

        magicLoaderFile.FullNames ??= new Dictionary<string, string>();
        // create new localization strings for the soul levels
        foreach (var (prefix, translationKey) in _soulLevels)
        {
            // get the filled translation if necessary
            if (prefix != "Filled" || _filledTranslations.TryGetValue(language, out var translation) == false)
            {
                // otherwise get the translation for the soul level from the ST_HardcodedContent section
                var key = $"{HardcodedSoulLevelPrefix}{prefix.Replace("Soul", "")}";

                translation = _localization.GetValueOrDefault(language, key, string.Empty);
            }
            // if a translation was found
            if (string.IsNullOrEmpty(translation) == false)
            {
                // add it to the FullNames entries
                magicLoaderFile.FullNames[translationKey] = translation;
            }
        }

        return magicLoaderFile;
    }

    protected override string FormatLine(string language, string key)
    {
        string? soulLevel = null;

        // try to match the soul level with the end of the localization key
        if ((key.EndsWith("Filled") && _soulLevels.TryGetValue("Filled", out var levelKey))
         || (key.EndsWith("PettySoul") && _soulLevels.TryGetValue("PettySoul", out levelKey))
         || (key.EndsWith("LesserSoul") && _soulLevels.TryGetValue("LesserSoul", out levelKey))
         || (key.EndsWith("CommonSoul") && _soulLevels.TryGetValue("CommonSoul", out levelKey))
         || (key.EndsWith("GreaterSoul") && _soulLevels.TryGetValue("GreaterSoul", out levelKey))
         || ((key.EndsWith("GrandSoul") || key.EndsWith("Grand")) && _soulLevels.TryGetValue("GrandSoul", out levelKey)))
        {
            soulLevel = $" ($[[{levelKey}]])";
        }

        return _localization.GetValueOrDefault(language, key, $"$[[{key}]]") + soulLevel;
    }
}
