using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
