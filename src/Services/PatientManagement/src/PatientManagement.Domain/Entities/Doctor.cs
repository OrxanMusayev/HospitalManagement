namespace PatientManagement.Domain.Entities;

public class Doctor: BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Address Address { get; set; }
    public ContactInformation ContactDetails { get; set; }

    public string GetFullName() => $"{Name} {Surname}";
}