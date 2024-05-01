using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class DependencyRegister
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(typeof(DependencyRegister).Assembly);
        });

        return services;
    }
}
