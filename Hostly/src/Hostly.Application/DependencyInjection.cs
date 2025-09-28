using Hostly.Application.Abstractions.Behaviors;
using Hostly.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;


namespace Hostly.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddTransient<PricingService>();

            return services;
        }
    }
}
