namespace Hostly.Domain;

public interface IApartamentRepository
{
    Task<Apartment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
