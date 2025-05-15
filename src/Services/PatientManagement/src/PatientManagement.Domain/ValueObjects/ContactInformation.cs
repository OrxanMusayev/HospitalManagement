namespace PatientManagement.Domain.ValueObjects;

[Owned]
public class ContactInformation: ValueObject
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public ContactInformation()
    {
        PhoneNumber = string.Empty;
        Email = string.Empty;
    }

    public ContactInformation(string phoneNumber, string email)
    {
        PhoneNumber = phoneNumber;
        Email = email;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumber;
        yield return Email;
    }
}