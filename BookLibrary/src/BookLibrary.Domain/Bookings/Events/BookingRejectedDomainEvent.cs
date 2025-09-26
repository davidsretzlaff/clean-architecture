namespace Hostly.Domain.Bookings;


public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
