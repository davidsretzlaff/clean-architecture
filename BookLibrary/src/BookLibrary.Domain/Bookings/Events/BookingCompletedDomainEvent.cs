using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Bookings;


public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
