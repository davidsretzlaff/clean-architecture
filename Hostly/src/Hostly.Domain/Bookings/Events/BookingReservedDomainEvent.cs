using Hostly.Domain.Hostly.Domain.Abstractions;

namespace Hostly.Domain.Hostly.Domain.Bookings.Events;


public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
