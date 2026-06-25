using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ByteSpot.Shared.Infrastructure.Modules;

internal static class Extensions
{
    public static IHostBuilder ConfigureModules(this IHostBuilder builder)
        => builder.ConfigureAppConfiguration((context, config) =>
        {
            foreach (var settings in GetSettings("*"))
            {
                config.AddJsonFile(settings);
            }
            
            foreach (var settings in GetSettings($"*{context.HostingEnvironment.EnvironmentName}"))
            {
                config.AddJsonFile(settings);
            }
            IEnumerable<string> GetSettings(string pattern) =>
                Directory.EnumerateFiles(context.HostingEnvironment.ContentRootPath, 
                    $"module.{pattern}.json",
                    SearchOption.AllDirectories);
        });
}