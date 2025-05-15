using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Interfaces;

public interface IPatientRepository
{
    Task<List<Patient?>> GetAll();
    Task<Patient?> GetById(int id);
    Task AddAsync(Patient patient);
    void Update(Patient patient);
    Task DeleteAsync(int id);
}