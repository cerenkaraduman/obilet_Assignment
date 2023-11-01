using Newtonsoft.Json;

namespace obilet_Assignment.Applicaiton.Common
{
    public class SesionData
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
