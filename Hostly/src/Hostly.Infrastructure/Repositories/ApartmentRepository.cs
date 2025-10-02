using Hostly.Domain.Apartments;

namespace Hostly.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
