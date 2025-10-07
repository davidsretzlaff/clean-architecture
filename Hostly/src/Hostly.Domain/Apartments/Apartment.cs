using Hostly.Domain.Abstractions;
using Hostly.Domain.Shared;

namespace Hostly.Domain.Apartments;


public sealed class Apartment : Entity
{
    public Apartment(Guid id) : base(id)
    {
    }

    private Apartment()
    {
    }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public Money CleaningFee { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<Amenity> Amenities { get; private set; } = new();
}
