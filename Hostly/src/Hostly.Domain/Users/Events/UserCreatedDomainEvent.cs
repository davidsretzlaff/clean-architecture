using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Users.Events;

public record class UserCreatedDomainEvent(Guid UserId) : IDomainEvent
{

}
