namespace PatientManagement.Domain.Entities;

public class MedicalHistory: BaseEntity
{
    public string PatientId { get; set; }
    public string Description { get; set; }        
    
}