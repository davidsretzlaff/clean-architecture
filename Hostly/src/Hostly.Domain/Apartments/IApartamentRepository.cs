namespace Hostly.Domain.Apartments;

public interface IApartamentRepository
{
    Task<Apartment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
