namespace ByteSpot.Shared.Infrastructure.Modules;

internal sealed class ModuleOptions
{
    public ModuleData Module { get; set; } = default!;

    public class ModuleData
    {
        public bool Enabled { get; set; }
    }
}