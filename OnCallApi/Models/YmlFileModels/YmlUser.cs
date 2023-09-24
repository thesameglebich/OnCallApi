using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace OnCallApi.Models.YmlFileModels
{
    public class YmlUser
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [YamlMember(Alias = "full_name")]
        public string FullName { get; set; }

        [YamlMember(Alias = "phone_number")]
        public string PhoneNumber { get; set; }

        [YamlMember(Alias = "email")]
        public string Email { get; set; }

        [YamlMember(Alias = "duty")]
        public ICollection<YmlDuty> Duties { get; set; }
    }
}
