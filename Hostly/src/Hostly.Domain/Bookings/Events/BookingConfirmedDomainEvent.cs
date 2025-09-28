using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings.Events;


public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
