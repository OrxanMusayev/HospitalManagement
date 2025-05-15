namespace PatientManagement.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}