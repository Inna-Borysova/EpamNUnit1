using Microsoft.Extensions.Configuration;

namespace EpamNUnit1.Helpers;

public class ConfigManager
{
    private readonly static ConfigManager _configManager = new ConfigManager();
    private readonly IConfigurationRoot _config;

    public static ConfigManager Instance => _configManager;

    private ConfigManager()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public string Browser => _config["TestSettings:Browser"];

    public bool Headless => bool.Parse(_config["TestSettings:Headless"]);

    public string Url => _config["TestSettings:Url"];
}
