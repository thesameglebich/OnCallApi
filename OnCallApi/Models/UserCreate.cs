using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnCallApi.Models
{
    public class UserCreate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
