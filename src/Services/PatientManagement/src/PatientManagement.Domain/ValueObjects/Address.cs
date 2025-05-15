using Microsoft.EntityFrameworkCore;

namespace PatientManagement.Domain.ValueObjects;

[Owned]
public class Address: ValueObject
{
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    
    public Address(string street, string city,string postalCode)
    {
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return PostalCode;
    }
}