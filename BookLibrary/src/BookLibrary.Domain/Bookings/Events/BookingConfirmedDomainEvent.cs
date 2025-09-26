namespace Hostly.Domain.Bookings;


public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
