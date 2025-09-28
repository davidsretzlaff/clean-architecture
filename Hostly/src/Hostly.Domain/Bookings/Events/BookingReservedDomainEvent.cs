using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings.Events;


public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
