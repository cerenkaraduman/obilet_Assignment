using Newtonsoft.Json;
using obilet_Assignment.Applicaiton.Common;

namespace obilet_Assignment.Applicaiton.Services.SessionService.Response
{
    public class GetSessionResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public SesionData Data { get; set; }
    }
}
