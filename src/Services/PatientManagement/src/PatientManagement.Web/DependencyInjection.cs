namespace PatientManagement.Web;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor(); 
        builder.Services.AddScoped<IUser, CurrentUser>();
    }
}