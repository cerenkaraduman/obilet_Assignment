

using obilet_Assignment.Applicaiton.Services.SessionService.Request;

namespace obilet_Assignment.Applicaiton.Common.HttpCall
{
    public interface IHttpCall
    {
        Task<HttpResponseMessage> PostCall<T>(T request, string ApiUrl, string token) where T : class;
    }
}
