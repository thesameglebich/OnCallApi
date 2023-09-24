using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace OnCallApi.Models.YmlFileModels
{
    public class YmlDuty
    {
        [YamlMember(Alias = "date")]
        public string DateString { get; set; }

        [YamlMember(Alias = "role")]
        public string Role { get; set; }

        public DateOnly Date => DateOnly.ParseExact(DateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
