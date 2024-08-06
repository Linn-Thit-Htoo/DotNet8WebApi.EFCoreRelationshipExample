namespace DotNet8WebApi.EFCoreRelationshipExample.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        return services.AddDbContextService(builder).AddRepositoryService();
    }

    private static IServiceCollection AddDbContextService(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<EfcoreTableJoinContext>(
            opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            },
            ServiceLifetime.Transient,
            ServiceLifetime.Transient
        );

        return services;
    }

    private static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        return services
            .AddScoped<IFeatureRepository, FeatureRepository>()
            .AddScoped<IPropertyRepository, PropertyRepository>();
    }
}
