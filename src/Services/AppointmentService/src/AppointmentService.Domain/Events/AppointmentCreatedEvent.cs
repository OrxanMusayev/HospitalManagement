namespace AppointmentService.Domain.Events;

public class AppointmentCreatedEvent: BaseEvent
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }

    public AppointmentCreatedEvent(int appointmentId, int patientId, int doctorId, DateTime appointmentDate)
    {
        AppointmentId = appointmentId;  
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentDate = appointmentDate;
    }
}