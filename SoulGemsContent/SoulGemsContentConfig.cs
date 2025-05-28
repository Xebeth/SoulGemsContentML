using Microsoft.Extensions.Configuration;
using MagicLoaderGenerator.Filesystem;

namespace SoulGemsContent;

public record SoulGemsContentConfig: AppConfig
{
    private static Dictionary<string, string> DefaultPrefixes => new() {
        { "sorted",  " " },
        { "default", ""  }
    };

    public SoulGemsContentConfig(IConfiguration config) : base(config) {}

    public Dictionary<string, string> Prefixes { get; } = DefaultPrefixes;
}
