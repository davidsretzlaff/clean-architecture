using Hostly.Application.Abstractions.Messaging;

namespace Hostly.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;
