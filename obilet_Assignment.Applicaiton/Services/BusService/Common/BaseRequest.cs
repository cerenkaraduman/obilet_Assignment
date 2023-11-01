using Newtonsoft.Json;
using obilet_Assignment.Applicaiton.Common;

namespace obilet_Assignment.Applicaiton.Services.BusService.Common
{
    public class BaseRequest
    {
        [JsonProperty("device-session")]
        public required SesionData DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";
    }
}
