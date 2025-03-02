namespace PatientManagement.Infrastructure.Data.Migrations;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
    
    public async Task TrySeedAsync()
    {
        if (!_context.Patients.Any())
        {
            _context.Patients.Add(new Patient()
            {
                Name = "Orxan",
                Surname = "Musayev",
                DateOfBirth = new DateTime(1999, 11, 2),
                Gender = Gender.Male,
                BloodType = new BloodType(BloodGroup.B, BlookRhFactor.Positive),
                ContactDetails = new ContactInformation()
                {
                    PhoneNumber = "+9955999071128",
                    Email = "orxan.musayev@gmail.com",
                }
            });
            
            _context.Patients.Add(new Patient()
            {
                Name = "Səlimə",
                Surname = "Musayeva",
                DateOfBirth = new DateTime(2003, 9, 1),
                Gender = Gender.Male,
                BloodType = new BloodType(BloodGroup.A, BlookRhFactor.Positive),
                ContactDetails = new ContactInformation()
                {
                    PhoneNumber = "+9955999071116",
                    Email = "salima.musayeva@gmail.com",
                }
            });
            
            _context.Doctors.Add(new Doctor()
            {
                Name = "Fuad",
                Surname = "Mehdiyev",
                ContactDetails = new ContactInformation()
                {
                    PhoneNumber = "+994516230537",
                    Email = "fuad.mehdiyev@gmail.com",
                }
            });

            _context.Appointments.Add(new Appointment()
            {
                PatientId = _context.Patients.First().Id,
                DoctorId = _context.Doctors.First().Id,
            });

            await _context.SaveChangesAsync();
        }
    }
}