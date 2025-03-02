namespace PatientManagement.Domain.Exceptions;

public class AppointmentNotFoundException : Exception
{
    public AppointmentNotFoundException(Guid appointmentId) 
        : base($"Appointment with ID '{appointmentId}' was not found.") { }
}