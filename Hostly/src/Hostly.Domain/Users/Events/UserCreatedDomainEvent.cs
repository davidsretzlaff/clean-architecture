using Hostly.Domain.Hostly.Domain.Abstractions;

namespace Hostly.Domain.Hostly.Domain.Users.Events;

public record class UserCreatedDomainEvent(Guid UserId) : IDomainEvent
{

}
