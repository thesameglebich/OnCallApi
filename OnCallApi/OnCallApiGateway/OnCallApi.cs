using System.Text.Json;
using OnCallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OnCallApi.OnCallApiGateway
{
    public class OnCallApi: IOnCallApi
    {
        const string baseOnCallUrl = "http://localhost:8080/api/v0/";

        public async Task<(string cookie, string token)> Login(HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            string authCook;
            var requestUrl = "http://localhost:8080/" + "login";
            var data = new StringContent("username=root&password=123456789i", Encoding.UTF8);

            try
            {
                var validationResponse = await httpClient.PostAsync(requestUrl, data);
                authCook = validationResponse.Headers.GetValues("Set-Cookie").First();
                validationResponseBody = await validationResponse.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }

            var validationResponseJson = JObject.Parse(validationResponseBody);
            var token = validationResponseJson.GetValue("csrf_token")?.ToObject<string>() ?? string.Empty;

            return (authCook, token);
        }
        
        public async Task<string> CreateTeam(Team team, HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            var requestUrl = baseOnCallUrl + "teams";

            string json = JsonSerializer.Serialize(team);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "error";
            try
            {
                var validationResponse = await httpClient.PostAsync(requestUrl, data);
                result = validationResponse.StatusCode == HttpStatusCode.Created ? "ok" : result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<string> CreateUser(UserCreate user, HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            var requestUrl = baseOnCallUrl + "users";

            string json = JsonSerializer.Serialize(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "error";
            try
            {
                var validationResponse = await httpClient.PostAsync(requestUrl, data);
                result = validationResponse.StatusCode == HttpStatusCode.Created ? "ok" : result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<string> CrateUserData(UserDataCreate userData, HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            var requestUrl = baseOnCallUrl + "users/" + userData.Name;

            string json = JsonSerializer.Serialize(userData);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "error";
            try
            {
                var validationResponse = await httpClient.PutAsync(requestUrl, data);
                result = validationResponse.StatusCode == HttpStatusCode.NoContent ? "ok" : result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<string> AddUserToTeam(string team, string userName, HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            var requestUrl = baseOnCallUrl + $"teams/{team}/users";

            string json = JsonSerializer.Serialize(new UserCreate
            {
                Name = userName
            });

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "error";
            try
            {
                var validationResponse = await httpClient.PostAsync(requestUrl, data);
                result = validationResponse.StatusCode == HttpStatusCode.Created ? "ok" : result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<string> AddEvent(EventCreate eventCreate, HttpClient httpClient)
        {
            var validationResponseBody = string.Empty;
            var requestUrl = baseOnCallUrl + "events";

            string json = JsonSerializer.Serialize(eventCreate);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "error";
            try
            {
                var validationResponse = await httpClient.PostAsync(requestUrl, data);
                result = validationResponse.StatusCode == HttpStatusCode.Created ? "ok" : result;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
