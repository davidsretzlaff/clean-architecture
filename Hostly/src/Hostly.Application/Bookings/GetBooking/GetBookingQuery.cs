using Hostly.Application.Abstractions.Messaging;

namespace Hostly.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>
{
}
