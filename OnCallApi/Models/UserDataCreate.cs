using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnCallApi.Models
{
    public class UserDataCreate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("contacts")]
        public Contacts Contacts { get; set; }
    }

    public class Contacts
    {
        [JsonPropertyName("call")]
        public string Call { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
