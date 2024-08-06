namespace DotNet8WebApi.EFCoreRelationshipExample.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder)
                .AddRepositoryService();
            return services;
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<EfcoreTableJoinContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            return services;
        }
    }
}
