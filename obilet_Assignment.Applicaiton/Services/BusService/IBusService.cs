using obilet_Assignment.Applicaiton.Services.BusService.Request;
using obilet_Assignment.Applicaiton.Services.BusService.Response;

namespace obilet_Assignment.Applicaiton.Services.BusService
{
    public interface IBusService
    {
        Task<GetLocationsResponse> GetBusLocations(GetLocationsRequest request);
        Task<GetJourneysResponse> GetBusJourneys(GetJourneysRequest request);
    }
}
