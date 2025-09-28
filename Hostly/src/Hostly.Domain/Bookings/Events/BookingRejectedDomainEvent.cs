using Hostly.Domain.Hostly.Domain.Abstractions;

namespace Hostly.Domain.Hostly.Domain.Bookings.Events;


public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
