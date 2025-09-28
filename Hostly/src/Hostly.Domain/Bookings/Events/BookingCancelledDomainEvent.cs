using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings.Events;


public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
