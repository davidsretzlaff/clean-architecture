namespace Hostly.Domain;

public record class UserCreatedDomainEvent(Guid UserId) : IDomainEvent
{

}
