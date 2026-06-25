using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ByteSpot.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    string Path { get; }
    void Register(IServiceCollection services);
    void Use(IApplicationBuilder builder);
    void Expose(WebApplication app);
}