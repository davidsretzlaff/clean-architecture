using Hostly.Application.Abstractions.Email;

namespace Hostly.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
