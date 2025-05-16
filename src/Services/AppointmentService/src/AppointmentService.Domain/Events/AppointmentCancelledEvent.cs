namespace AppointmentService.Domain.Events;

public class AppointmentCancelledEvent : BaseEvent
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime CancellationDate { get; set; }
    public string CancellationReason { get; set; }

    public AppointmentCancelledEvent(int appointmentId, int patientId, int doctorId, DateTime cancellationDate,
        string cancellationReason)
    {
        AppointmentId = appointmentId;
        PatientId = patientId;
        DoctorId = doctorId;
        CancellationDate = cancellationDate;
        CancellationReason = cancellationReason;
    }
}