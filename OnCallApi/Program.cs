using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OnCallApi.Models;
using OnCallApi.Models.YmlFileModels;
using System.Globalization;
using System.IO;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

class Program
{
    static HttpClient httpClient = new HttpClient();

    static async Task Main()
    {
        var yamlDeserializer = new DeserializerBuilder()
            .Build();
        var yamlText = File.ReadAllText("C:\\Users\\DNS\\source\\repos\\OnCallApi\\OnCallApi\\tinkoffData.yaml");
        var yamlObject = yamlDeserializer.Deserialize<YmlFile>(yamlText);

        var onCallApiService = new OnCallApi.OnCallApiGateway.OnCallApi();
        (string authCookie, string token) = await onCallApiService.Login(httpClient);
        httpClient.DefaultRequestHeaders.Add("Cookie", authCookie);
        httpClient.DefaultRequestHeaders.Add("X-Csrf-Token", token);
        
        foreach (var yamlTeam in yamlObject.Teams)
        {
            var team = new Team
            {
                Name = yamlTeam.Name,
                Email = yamlTeam.Email,
                SchedulingTimezone = yamlTeam.SchedulingTimezone,
                SlackChannel = yamlTeam.SlackChannel
            };

            var result = await onCallApiService.CreateTeam(team, httpClient);
            if (result != "ok")
            {
                Console.WriteLine("create team error");
                return;
            }

            Thread.Sleep(1000);

            foreach (var yamlUser in yamlTeam.Users)
            {
                var user = new UserCreate { Name = yamlUser.Name };
                result = await onCallApiService.CreateUser(user, httpClient);
                if (result != "ok")
                {
                    Console.WriteLine("create user error");
                    return;
                }

                var userData = new UserDataCreate
                {
                    Name = yamlUser.Name,
                    FullName = yamlUser.FullName,
                    Contacts = new Contacts
                    {
                        Call = yamlUser.PhoneNumber,
                        Email = yamlUser.Email,
                    }
                };

                result = await onCallApiService.CrateUserData(userData, httpClient);
                if (result != "ok")
                {
                    Console.WriteLine("update user error");
                    return;
                }

                Thread.Sleep(1000);

                result = await onCallApiService.AddUserToTeam(team.Name, user.Name, httpClient);
                if (result != "ok")
                {
                    Console.WriteLine("add user to team error");
                    return;
                }

                Thread.Sleep(1000);

                foreach (var yamlDuty in yamlUser.Duties)
                {
                    var startTime = new DateTimeOffset(yamlDuty.Date.ToDateTime(new TimeOnly(0, 0))).ToUnixTimeSeconds();
                    var endTime = new DateTimeOffset(yamlDuty.Date.ToDateTime(new TimeOnly(0, 0))).AddDays(1).ToUnixTimeSeconds();

                    var duty = new EventCreate
                    {
                        Start = startTime,
                        End = endTime,
                        Role = yamlDuty.Role,
                        TeamName = team.Name,
                        UserName = user.Name
                    };

                    result = await onCallApiService.AddEvent(duty, httpClient);
                    if (result != "ok")
                    {
                        Console.WriteLine("add event error");
                        return;
                    }

                    Thread.Sleep(1000);
                }
            }
        }
    }
}


