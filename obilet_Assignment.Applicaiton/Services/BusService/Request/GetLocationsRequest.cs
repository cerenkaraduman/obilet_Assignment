using Newtonsoft.Json;
using obilet_Assignment.Applicaiton.Services.BusService.Common;

namespace obilet_Assignment.Applicaiton.Services.BusService.Request
{
    public class GetLocationsRequest : BaseRequest
    {
        [JsonProperty("data")]
        public string? Data { get; set; }
    }
}
