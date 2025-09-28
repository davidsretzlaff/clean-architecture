using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings;


public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
