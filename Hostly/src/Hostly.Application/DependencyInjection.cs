using FluentValidation;
using Hostly.Application.Abstractions.Behaviors;
using Hostly.Domain.Bookings;
using MediatR;
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
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            
            services.AddTransient<PricingService>();

            return services;
        }
    }
}
