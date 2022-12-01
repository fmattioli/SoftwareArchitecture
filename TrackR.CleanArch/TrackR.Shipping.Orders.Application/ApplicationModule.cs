namespace TrackR.Shipping.Orders.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using TrackR.Shipping.Orders.Application.Services;

    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
               .AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingServiceService, ShippingServiceService>();
            return services;
        }
    }
}
