using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TNN.Infra.Config;
using TNN.Domain.Tasks;

namespace TNN.Infra.Di;
public class LoadConfig
{
    public static IConfigurationRoot CreateConfiguration()
    {
        string environment =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "dev";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environment}.json", false)
            .Build();

        ConfigurationBridge(configuration);
        EnvironmentConfiguration();

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


    public static ServiceProvider InjectValues(string pathDrive)
    {
        ServiceProvider serviceProvider = new ServiceCollection()
        .AddSingleton<ChromeDriver>(x =>
        {
            var driver = new ChromeDriver(pathDrive);
            driver.Navigate().GoToUrl(ValuesConfig.ScrappingProperties.Host);
            TryTask.Try(() => driver.FindElement(By.Id("codcliente")).SendKeys("22582" + Keys.Return));

            TryTask.Try(()=> driver.FindElement(By.Id("username")).SendKeys("TESOURARIACM24"));
            driver.FindElement(By.Id("password")).SendKeys("cm1309");
            driver.FindElement(By.Id("btnsend")).Click();

            Thread.Sleep(2000);

            return driver;
        })
        .BuildServiceProvider();

        return serviceProvider;
    }
}
