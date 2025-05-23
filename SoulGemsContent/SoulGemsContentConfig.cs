using Microsoft.Extensions.Configuration;
using MagicLoaderGenerator.Filesystem;

namespace SampleModML;

public record SoulGemsContentConfig: AppConfig
{
    public SoulGemsContentConfig(IConfiguration config) : base(config) {}

    public Dictionary<string, string> SoulLevels { get; init; } = [];
}
