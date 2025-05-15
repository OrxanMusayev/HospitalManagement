namespace PatientManagement.Domain.Entities;

[Owned]
public class MedicalHistory: BaseEntity
{
    public string PatientId { get; set; }
    public string Description { get; set; }        
    
}