using Newtonsoft.Json;
using obilet_Assignment.Applicaiton.Services.BusService.Common;

namespace obilet_Assignment.Applicaiton.Services.BusService.Request
{
    public class GetJourneysRequest : BaseRequest
    {
        [JsonProperty("data")]
        public required Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public required DateTime DepartureDate { get; set; }
    }
}
