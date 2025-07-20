using Microsoft.Extensions.Configuration;

namespace EpamNUnit1.Helpers;

public class ConfigManager
{
    private readonly static IConfigurationRoot _config;

    static ConfigManager()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static string Browser => _config["TestSettings:Browser"];

    public static bool Headless => bool.Parse(_config["TestSettings:Headless"]);

    public static string Url => _config["TestSettings:Url"];
}
