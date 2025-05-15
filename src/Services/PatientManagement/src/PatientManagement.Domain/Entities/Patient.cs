namespace PatientManagement.Domain.Entities;

public class Patient: BaseAuditableEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }      
    public BloodType BloodType { get; set; }
    public Address Address { get; set; }
    public ContactInformation ContactDetails { get; set; }
    [ForeignKey(nameof(Doctor))]
    public int? PrimaryDoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int? MedicalHistoryId { get; set; }
    public MedicalHistory? MedicalHistory { get; set; }
}