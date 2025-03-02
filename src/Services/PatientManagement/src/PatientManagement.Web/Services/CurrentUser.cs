using PatientManagement.Application.Interfaces;

namespace PatientManagement.Web.Services;

public class CurrentUser: IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id => _httpContextAccessor.HttpContext?.Request?.Headers["X-User-Id"].ToString();
}