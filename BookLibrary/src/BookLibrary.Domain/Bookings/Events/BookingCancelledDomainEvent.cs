using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings;


public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
