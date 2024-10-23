using Microsoft.Extensions.Configuration;
using TNN.Infra.Config;
using static TNN.Infra.Config.ValuesConfig;

namespace TNN.Infra.Di;
public class LoadConfig
{
    public static IConfigurationRoot CreateConfiguration()
    {
        string environment = 
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "dev";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings{environment}.json", false)
            .Build();

        ConfigurationBridge(configuration);

        return configuration;
    }
    public static void EnvironmentConfiguration()
    {
        ValuesConfig.ScrappingProperties.UserClient = 
            Environment.GetEnvironmentVariable("USER_CLIENT") ?? "";

        ValuesConfig.ScrappingProperties.UserName =
            Environment.GetEnvironmentVariable("USER_NAME") ?? "";

        ValuesConfig.ScrappingProperties.Password =
            Environment.GetEnvironmentVariable("PASSWORD") ?? "";
    }
    public static void ConfigurationBridge(IConfigurationRoot config)
    {
        config.GetSection("ScrappingValues").Bind(ValuesConfig.ScrappingProperties);
    }
}
