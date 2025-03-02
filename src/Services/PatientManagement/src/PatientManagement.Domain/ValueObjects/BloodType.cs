namespace PatientManagement.Domain.ValueObjects;

public class BloodType: ValueObject
{
    
    public BloodGroup Group { get; set; }
    public BlookRhFactor Rh { get; set; }
    
    public BloodType(BloodGroup group, BlookRhFactor rh)
    {
        Group = group;
        Rh = rh;
    }

    public string GetFullBloodType()
    {
        return $"{Group} {Rh}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Group;
        yield return Rh;
    }
}