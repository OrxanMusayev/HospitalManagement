using PatientManagement.Application.Interfaces;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> SaveChangesAsync()
    { 
        return await _dbContext.SaveChangesAsync();
    }
}