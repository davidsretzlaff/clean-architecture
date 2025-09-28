using Hostly.Domain.Hostly.Domain.Shared;

namespace Hostly.Domain.Hostly.Domain.Bookings;

public record PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);