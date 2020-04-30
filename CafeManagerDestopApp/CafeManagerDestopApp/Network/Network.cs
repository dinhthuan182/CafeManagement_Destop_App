using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using CafeManagerDestopApp.Entitys;

namespace CafeManagerDestopApp.Network
{
    public class Network: ApiController
    {
        static HttpClient client = new HttpClient();

        private static readonly string BASE_URL = "http://cafe-management-system.herokuapp.com";
        private static readonly string BASE_API = BASE_URL + "/api";

        private static readonly string LOGIN = BASE_API + "/login";
        private static readonly string LOGOUT = BASE_API + "/logout";
        private static readonly string ALL_TABLE = BASE_API + "/tables";
        private static string TABLE_DETAIL(int id)
        {
            return BASE_API + id;
        }

        private static string UNSTATE_TABLE(int id)
        {
            return ALL_TABLE + "/" + id + "/unstate";
        }

        private static string GET_BILL(int id)
        {
            return BASE_API + "/receipts/bill/" + id;
        }

        private static string PAYMENT(int id)
        {
            return BASE_API + "/receipts/paid/" + id;
        }

        public Network()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<String> LoginAsync(String username, String password)
        {
            client.BaseAddress = new Uri(LOGIN);
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
                User user = jObject.GetValue("user").ToObject<User>();
                var expires = Convert.ToInt32(jObject.GetValue("expires_in"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // set token global
                AuthGlobals.access_token = token;
                AuthGlobals.user = user;
                AuthGlobals.expires_in = expires;

                return token;
            } catch
            {
            }
            return null;
        }

        public async Task<Boolean> LogoutAsync()
        {
            client.BaseAddress = new Uri(LOGOUT);
            try
            {
                // set token global
                AuthGlobals.access_token = null;
                AuthGlobals.user = null;
                AuthGlobals.expires_in = 0;
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync("logout", null);
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                return true;
            }
            catch
            {
            }
            return false;
        }

        public async Task<String> getTables()
        {
            client.BaseAddress = new Uri(ALL_TABLE);
            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync("tables");
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                return null;
            }
            catch
            {
            }
            return null;
        }

        public async Task<String> getTableDetail(int id)
        {
            client.BaseAddress = new Uri(TABLE_DETAIL(id));
            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync("detail");
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                return null;
            }
            catch
            {
            }
            return null;
        }
    }
}
