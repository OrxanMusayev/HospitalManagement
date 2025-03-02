using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientManagement.Infrastructure.Data;
using PatientManagement.Infrastructure.Data.Migrations;

namespace PatientManagement.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>()!);
            
            options.UseSqlServer(connectionString);
        });
        
        builder.Services.AddScoped<ApplicationDbContextInitializer>();

        
    }
}