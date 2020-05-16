using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using CafeManagerDestopApp.Entitys;
using Newtonsoft.Json;

namespace CafeManagerDestopApp.Network
{
    public enum PrintType
    {
        Bill,
        Receipt,
        Drink,
        Food
    }

    public class Network: ApiController
    {
        
        private static HttpClient client = new HttpClient();

        private static readonly string BASE_URL = "http://cafe-management-system.herokuapp.com";
        private static readonly string BASE_API = BASE_URL + "/api";

        private static readonly string LOGIN = BASE_API + "/login";
        private static readonly string LOGOUT = BASE_API + "/logout";
        private static readonly string ALL_TABLE = BASE_API + "/tables";
        private static readonly string CHECKIN = BASE_API + "/check";
        private static string TABLE_DETAIL(int id)
        {
            return ALL_TABLE + "/" + id;
        }

        private static string UNSTATE_TABLE(int id)
        {
            return ALL_TABLE + "/" + id + "/unstate";
        }

        private static string GET_BILL(int id)
        {
            return BASE_API + "/receipts/bill/" + id;
        }

        private static string GET_RECEIPT(int id)
        {
            return BASE_API + "/receipts/paid/" + id;
        }

        public Network()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<Tuple<Boolean, String>> LoginAsync(String username, String password)
        {
            //client.BaseAddress = new Uri(LOGIN);
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        //new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                    });
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(LOGIN, formContent);
                
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);

                // Call Api checkin
                var checkin = CheckinAsync(username).Result;

                if (checkin.Item1 == true)
                {
                    var token = jObject.GetValue("access_token").ToString();
                    User user = jObject.GetValue("user").ToObject<User>();
                    var expires = Convert.ToInt32(jObject.GetValue("expires_in"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // set token global
                    AuthGlobals.access_token = token;
                    AuthGlobals.user = user;
                    AuthGlobals.expires_in = expires;

                    return Tuple.Create(true, token);
                } else
                {
                   return checkin;
                }

            } catch
            {
            }
            return null;
        }

        public async Task<Tuple<Boolean, String>> CheckinAsync(String username)
        {
            //client.BaseAddress = new Uri(LOGIN);
            try
            {
                var values = new Dictionary<string, string>();
                values.Add("username", username);
                var content = new FormUrlEncodedContent(values);
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(CHECKIN, content).ConfigureAwait(false);
                //get message
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                var message = jObject.GetValue("message").ToString();
                var state = false;
                if((int)responseMessage.StatusCode == 200)
                {
                    state = true;
                }

                return Tuple.Create(state, message);
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<Boolean> LogoutAsync()
        {
            //client.BaseAddress = new Uri(LOGOUT);
            try
            {
                // set token global
                AuthGlobals.access_token = null;
                AuthGlobals.user = null;
                AuthGlobals.expires_in = 0;
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(LOGOUT, null);
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

        public async Task<List<TableItem>> GetAllTable()
        {

            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync(ALL_TABLE);
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(responseJson);

                var resultObjects = AllChildren(jObject).First(c => c.Type == JTokenType.Array && c.Path.Contains("tables")).Children<JObject>();

                var tables = new List<TableItem>();
                foreach (JObject result in resultObjects)
                {
                    TableItem t = result.ToObject<TableItem>();
                    tables.Add(t);
                }

                return tables;
            }
            catch
            {
            }
            return null;
        }

        public async Task<TableDetailItem> getTableDetail(int id)
        {

            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync(TABLE_DETAIL(id));
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                TableDetailItem detail = jObject.ToObject<TableDetailItem>();
                Console.WriteLine(detail.receipt_id);
                return detail;
            }
            catch
            {
            }
            return null;
        }

        public async Task<Boolean> UnstateAsync(int id)
        {

            try
            {
                // set token global
                AuthGlobals.access_token = null;
                AuthGlobals.user = null;
                AuthGlobals.expires_in = 0;
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync(UNSTATE_TABLE(id));
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

        public async Task<Boolean> GetBillAsync(int id)
        {

            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync(GET_BILL(id));
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

        public async Task<Boolean> GetReceiptAsync(int id)
        {

            try
            {
                //send request
                HttpResponseMessage responseMessage = await client.GetAsync(GET_RECEIPT(id));
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

        public void DownloadFileToLocal(string fileName, PrintType fileType)
        {
            using (WebClient webClient = new WebClient())
            {
                
                switch (fileType)
                {
                    case PrintType.Bill:
                        webClient.DownloadFile(fileName, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Bills\\" + fileName);
                        
                        break;
                    case PrintType.Receipt:
                        webClient.DownloadFile(fileName, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Receipts\\" + fileName);
                        
                        break;
                    case PrintType.Food:
                        webClient.DownloadFile(fileName, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Orders\\Foods\\" + fileName);
                        
                        break;
                    case PrintType.Drink:
                        webClient.DownloadFile(fileName, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Orders\\Drinks\\" + fileName);
                        
                        break;
                }
            }
            
        }

        // recursively yield all children of json
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }

    }
}
