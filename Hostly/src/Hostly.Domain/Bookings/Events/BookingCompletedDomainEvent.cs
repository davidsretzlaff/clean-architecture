using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings.Events;


public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
