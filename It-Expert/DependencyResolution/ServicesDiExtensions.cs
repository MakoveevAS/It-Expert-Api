using It_Expert.Services;
using It_Expert.Services.Interfaces;

namespace It_Expert.DependencyResolution;

public static class ServicesDiExtensions
{
    public static IServiceCollection AddServicesDi(this IServiceCollection services)
    {
        return services.AddScoped<IDataService, DataService>();
    }
}
