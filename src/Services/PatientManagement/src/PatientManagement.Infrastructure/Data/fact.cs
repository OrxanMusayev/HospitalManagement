using Microsoft.EntityFrameworkCore.Design;

namespace PatientManagement.Infrastructure.Data;


public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PatientPatientManagementDB;User Id=sa;Password=MyStrongPassword123;TrustServerCertificate=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}