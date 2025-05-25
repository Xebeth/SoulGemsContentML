using MagicLoaderGenerator.Localization.Abstractions;
using MagicLoaderGenerator.Localization.Transforms;
using MagicLoaderGenerator.Localization.Providers;
using MagicLoaderGenerator.Filesystem;

namespace SoulGemsContent;

public class SoulGemSuffixTransform(ILocalizationProvider localization, SoulGemsContentConfig config, string prefix):
    TranslateFileTransform(localization)
{
    private readonly Dictionary<string, string> _soulLevels = config.SoulLevels;

    /// <inheritdoc/>
    public override MagicLoaderFile Transform(string language, ModFile modFile)
    {
        var result = base.Transform(language, modFile);

        result.FullNames ??= [];

        // create new localization strings for the soul levels
        foreach (var (soulLevelKey, translationKey) in _soulLevels)
        {
            var translation = Localization.GetValueOrDefault(language, translationKey);

            if (string.IsNullOrWhiteSpace(translation) == false)
            {
                result.FullNames[soulLevelKey] = translation;
            }
        }

        return result;
    }

    /// <inheritdoc/>
    protected override string FormatLine(string language, string key)
    {
        return $"{prefix}{Translate(language, key)}{GetSoulLevel(key)}";
    }

    private static string? GetSoulLevel(string key)
    {
        string? levelKey = null;

        // try to match the soul level with the end of the localization key
        if (key.EndsWith("Filled"))
            levelKey = "LOC_FN_SoulLevelNameFilled";
        if (key.EndsWith("PettySoul"))
            levelKey = "LOC_FN_SoulLevelNamePetty";
        if (key.EndsWith("LesserSoul"))
            levelKey = "LOC_FN_SoulLevelNameLesser";
        if (key.EndsWith("CommonSoul"))
            levelKey = "LOC_FN_SoulLevelNameCommon";
        if (key.EndsWith("GreaterSoul"))
            levelKey = "LOC_FN_SoulLevelNameGreater";
        if (key.EndsWith("GrandSoul") || key.EndsWith("Grand"))
            levelKey = "LOC_FN_SoulLevelNameGrand";

        return levelKey != null ? $" ({BaseLocalizationProvider.MarkerStart}{levelKey}{BaseLocalizationProvider.MarkerEnd})" : null;
    }
}
