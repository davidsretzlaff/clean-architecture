using Hostly.Domain.Abstractions;

namespace Hostly.Domain.Apartments;


public sealed class Apartment : Entity
{
    public Apartment(Guid id) : base(id)
    {
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Address { get; private set; }

    public decimal Price { get; private set; }

    public decimal CleaningFee { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
