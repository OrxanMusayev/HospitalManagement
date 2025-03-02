using Microsoft.OpenApi.Services;
using PatientManagement.Application.Interfaces;
using PatientManagement.Web.Services;

namespace PatientManagement.Web;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUser, CurrentUser>();
    }
}