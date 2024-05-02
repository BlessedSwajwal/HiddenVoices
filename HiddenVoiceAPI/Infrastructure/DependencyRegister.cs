using Application.Services.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("HiddenVoicesDb")));

        //Repos
        services.AddScoped<IConfessionRepository, ConfessionRepository>();
        services.AddScoped<IReplyRepository, ReplyRepository>();

        return services;
    }
}

