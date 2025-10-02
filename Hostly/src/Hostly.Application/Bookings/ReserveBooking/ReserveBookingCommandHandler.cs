using Hostly.Application.Abstractions.Clock;
using Hostly.Application.Abstractions.Messaging;
using Hostly.Application.Exceptions;
using Hostly.Domain.Abstractions;
using Hostly.Domain.Apartments;
using Hostly.Domain.Bookings;
using Hostly.Domain.Users;

namespace Hostly.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;   
    private readonly PricingService _pricingService;
    private readonly IDateTimeProvider _dateTimeProvider;
 
    public ReserveBookingCommandHandler(
        IBookingRepository bookingRepository,
        IApartmentRepository apartmentRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingService,
        IDateTimeProvider dateTimeProvider)
    {
        _bookingRepository = bookingRepository;
        _apartmentRepository = apartmentRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId, cancellationToken);
        if (apartment is null)
        {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);    
        if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
        
        try 
        {
             var booking = Booking.Reserve(apartment, user.Id, duration, _dateTimeProvider.UtcNow, _pricingService);        
            _bookingRepository.Add(booking);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return booking.Id;
        }
        catch (ConcurrencyException ex)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
      
    }
}
