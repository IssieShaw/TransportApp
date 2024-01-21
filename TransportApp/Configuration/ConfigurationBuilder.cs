using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilder
{
    public static AppConfig BuildConfiguration()
    {
        IConfiguration configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        var appConfig = new AppConfig();
        configuration.Bind("AppSettings", appConfig);

        return appConfig;
    }
}
