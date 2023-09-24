using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace OnCallApi.Models.YmlFileModels
{
    public class YmlFile
    {
        [YamlMember(Alias = "teams")]
        public ICollection<YmlTeam> Teams { get; set; }
    }
}
