namespace PatientManagement.Domain.Entities;

public class Appointment: BaseAuditableEntity
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public AppointmentStatus Status { get; set; }
}