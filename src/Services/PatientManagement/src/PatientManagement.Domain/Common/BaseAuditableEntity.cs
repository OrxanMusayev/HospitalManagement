namespace PatientManagement.Domain.Common;

public class BaseAuditableEntity: BaseEntity
{
    //Alterative for DateTime (maybe DatetimOffset and why?)
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}