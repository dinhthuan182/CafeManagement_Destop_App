using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace CafeManagerDestopApp.Network
{
    public class Network: ApiController
    {
        static HttpClient client = new HttpClient();
        private static string baseUrlString = "http://cafe-management-system.herokuapp.com/api/";
        public Network()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<String> LoginAsync(String username, String password)
        {
            client.BaseAddress = new Uri(baseUrlString + "login");
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                    });
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync("login", formContent);
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                var token = jObject.GetValue("access_token").ToString();
                return token;
            } catch
            {
            }
            return null;
        }
    }
}
