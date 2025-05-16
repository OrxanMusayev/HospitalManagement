namespace AppointmentService.API;

public static class DependencyInjection
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
    }
}