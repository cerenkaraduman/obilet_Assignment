using obilet_Assignment.Applicaiton.Services.SessionService.Response;

namespace obilet_Assignment.Applicaiton.Services.SessionService
{
    public interface ISessionService
    {
        Task<GetSessionResponse> GetSesion();
    }
}
