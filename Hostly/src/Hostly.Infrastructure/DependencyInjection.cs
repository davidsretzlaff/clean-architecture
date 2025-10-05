using Dapper;
using Hostly.Application.Abstractions.Clock;
using Hostly.Application.Abstractions.Data;
using Hostly.Application.Abstractions.Email;
using Hostly.Domain.Abstractions;
using Hostly.Domain.Apartments;
using Hostly.Domain.Bookings;
using Hostly.Domain.Reviews;
using Hostly.Domain.Users;
using Hostly.Infrastructure.Clock;
using Hostly.Infrastructure.Data;
using Hostly.Infrastructure.Email;
using Hostly.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hostly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database") ?? 
            throw new ArgumentNullException(nameof(configuration));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork, ApplicationDbContext>( sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
