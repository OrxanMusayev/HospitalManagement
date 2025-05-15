using PatientManagement.Application.DTOs;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Interfaces;

public interface IPatientService
{
    Task<List<PatientDto>> GetPatientsAsync();
    Task<PatientDto> GetPatientByIdAsync(int id);
    Task AddPatient(PatientDto patient);
    Task DeletePatientAsync(int id);
    Task UpdatePatient(PatientDto patient);
}