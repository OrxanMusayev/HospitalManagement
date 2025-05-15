using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientManagement.Application.Interfaces;
using PatientManagement.Application.Services;

namespace PatientManagement.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPatientService, PatientService>();
    }
}