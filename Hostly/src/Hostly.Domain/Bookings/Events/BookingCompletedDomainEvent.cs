using Hostly.Domain.Hostly.Domain.Abstractions;

namespace Hostly.Domain.Hostly.Domain.Bookings.Events;


public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
