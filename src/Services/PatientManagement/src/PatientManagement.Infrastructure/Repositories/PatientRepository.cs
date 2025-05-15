using PatientManagement.Application.Interfaces;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PatientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Patient?>> GetAll()
    {
        return await _dbContext.Patients.AsNoTracking().ToListAsync();
    }

    public async Task<Patient?> GetById(int id)
    {
        return await _dbContext.Patients.AsNoTracking().Include(p=>p.Doctor).FirstOrDefaultAsync(p => p.Id == id)!;
    }

    public async Task AddAsync(Patient patient)
    {
        await _dbContext.Patients.AddAsync(patient);
    }
    
    public async Task DeleteAsync(int id)
    {
        var patient = await _dbContext.Patients.FindAsync(id);
        if (patient is null) throw new KeyNotFoundException($"Patient with ID {id} not found.");
        _dbContext.Patients.Remove(patient);
    }

    public void Update(Patient patient)
    {
        _dbContext.Patients.Update(patient);
    }
}