namespace PatientManagement.Domain.Exceptions;

public class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(Guid doctorId, DateTime dateTime) 
        : base($"Doctor with ID '{doctorId}' is not available at {dateTime}.") { }
}