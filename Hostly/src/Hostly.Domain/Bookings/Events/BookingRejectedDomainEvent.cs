using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings.Events;


public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
