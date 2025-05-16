using AppointmentService.Application.Interfaces;

namespace AppointmentService.API.Services;

public class CurrentUser: IUser
{
    IHttpContextAccessor _httpContextAccessor;
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string? Id => _httpContextAccessor.HttpContext?.Request?.Headers["X-User-Id"].ToString();
}