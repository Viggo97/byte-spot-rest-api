using System.Reflection;
using ByteSpot.Infrastructure;
using ByteSpot.Shared.Abstractions.Modules;
using ByteSpot.Shared.Infrastructure.Modules;

namespace ByteSpot.Bootstrapper;

internal static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
    {
        const string modulePart = "ByteSpot.Modules.";
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
        var files = Directory
            .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(f => !locations.Contains(f, StringComparer.InvariantCultureIgnoreCase))
            .ToList();
        
        var disabledModules = new List<string>();

        foreach (var file in files)
        {
            if (!file.Contains(modulePart))
            {
                continue;
            }

            var moduleName = file.Split(modulePart)[1].Split(".")[0].ToLowerInvariant();
            var moduleOptions = configuration.GetOptions<ModuleOptions>(moduleName);
            var enabled = moduleOptions.Module.Enabled;

            if (!enabled)
            {
                disabledModules.Add(file);
            }
        }

        foreach (var disabledModule in disabledModules)
        {
            files.Remove(disabledModule);
        }
        
        files.ForEach(f => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f))));

        return assemblies;
    }
    
    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface)
            .OrderBy(t => t.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
}