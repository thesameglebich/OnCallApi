using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnCallApi.Models
{
    public class Team
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("scheduling_timezone")]
        public string SchedulingTimezone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get;set; }

        [JsonPropertyName("slack_channel")]
        public string SlackChannel { get; set; }
    }
}
