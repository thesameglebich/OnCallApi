using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnCallApi.Models
{
    public class EventCreate
    {
        [JsonPropertyName("start")]
        public long Start { get; set; }

        [JsonPropertyName("end")]
        public long End { get; set; }

        [JsonPropertyName("user")]
        public string UserName { get; set; }

        [JsonPropertyName("team")]
        public string TeamName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
