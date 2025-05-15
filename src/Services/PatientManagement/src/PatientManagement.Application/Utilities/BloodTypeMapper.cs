using PatientManagement.Domain.Enums;
using PatientManagement.Domain.ValueObjects;

namespace PatientManagement.Application.Utilities;

public class BloodTypeMapper
{
    public static BloodType FromCombinedString(string? combined)
    {
        var parts = combined.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2)
            throw new ArgumentException("BloodType format invalid. Use e.g. 'A +'");

        var groupParsed = Enum.TryParse<BloodGroup>(parts[0], true, out var group);
        var rhParsed = parts[1] switch
        {
            "+" or "Positive" => BlookRhFactor.Positive,
            "-" or "Negative" => BlookRhFactor.Negative,
            _ => throw new ArgumentException("Invalid Rh factor")
        };

        if (!groupParsed)
            throw new ArgumentException("Invalid blood group");

        return new BloodType(group, rhParsed);
    }

}