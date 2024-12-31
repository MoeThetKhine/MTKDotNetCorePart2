namespace MTKDotNetCorePart2.NLayer;

#region DependencyInjection

public static class DependencyInjection
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        return services.AddScoped<DA_Blog>().AddScoped<BL_Blog>();
    }
}

#endregion