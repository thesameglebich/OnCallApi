using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace OnCallApi.Models.YmlFileModels
{
    public class YmlTeam
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [YamlMember(Alias = "scheduling_timezone")]
        public string SchedulingTimezone { get; set; }

        [YamlMember(Alias = "email")]
        public string Email { get; set; }

        [YamlMember(Alias = "slack_channel")]
        public string SlackChannel { get; set; }

        [YamlMember(Alias = "users")]
        public ICollection<YmlUser> Users { get; set; }
    }
}
