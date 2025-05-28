using MagicLoaderGenerator.Localization.Transforms;

namespace SoulGemsContent;

public class SoulGemSuffixTransform(string prefix):
    BaseMagicLoaderFileTransform
{
    /// <inheritdoc/>
    protected override string FormatLine(string key)
    {
        return $"{prefix}{base.FormatLine(key)}{GetSoulLevel(key)}";
    }

    private string? GetSoulLevel(string key)
    {
        string? levelKey = null;

        // try to match the soul level with the end of the localization key
        if (key.EndsWith("Filled") && key.Contains("MG17Misc") == false)
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNameGrand";
        if (key.EndsWith("PettySoul"))
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNamePetty";
        if (key.EndsWith("LesserSoul"))
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNameLesser";
        if (key.EndsWith("CommonSoul"))
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNameCommon";
        if (key.EndsWith("GreaterSoul"))
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNameGreater";
        if (key.EndsWith("GrandSoul"))
            levelKey = "LOC_HC_TESSoulGem_sSoulLevelNameGrand";

        return levelKey != null ? $" ({base.FormatLine(levelKey)})" : null;
    }
}
