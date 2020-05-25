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
using System.IO;

namespace CafeManagerDestopApp.Network
{
    public enum PrintType
    {
        Bill,
        Receipt,
        Order
    }

    public class Network: ApiController
    {
        
        private static HttpClient client = new HttpClient();

        private static readonly string BASE_URL = "http://cafe-management-system.herokuapp.com";
        private static readonly string BASE_API = BASE_URL + "/api";

        private static readonly string LOGIN = BASE_API + "/login";
        private static readonly string LOGOUT = BASE_API + "/logout";
        private static readonly string ALL_TABLE = BASE_API + "/tables";
        private static readonly string CHECKIN = BASE_API + "/checkin";
        private static readonly string CHECKOUT = BASE_API + "/checkout";
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
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                    });

                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(LOGIN, formContent);
                
                //get access token from response body
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);

                // Call Api checkin
                //var checkin = CheckinAsync(username).Result;

                //if (checkin.Item1 == true)
                //{
                    var token = jObject.GetValue("access_token").ToString();
                    User user = jObject.GetValue("user").ToObject<User>();
                    var expires = Convert.ToInt32(jObject.GetValue("expires_in"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // set token global
                    AuthGlobals.access_token = token;
                    AuthGlobals.user = user;
                    AuthGlobals.expires_in = expires;

                    return Tuple.Create(true, token);
                //} else
                //{
               //    return checkin;
               // }

            } catch
            {
            }
            return null;
        }

        public async Task<Tuple<Boolean, String>> CheckinAsync(String username)
        {
            try
            {
                var values = new Dictionary<string, string>();
                values.Add("username", username);
                var content = new FormUrlEncodedContent(values);
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(CHECKIN, content).ConfigureAwait(true);
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

        public async Task<Tuple<Boolean, String>> CheckoutAsync(String username)
        {
            try
            {
                var values = new Dictionary<string, string>();
                values.Add("username", username);
                var content = new FormUrlEncodedContent(values);
                //send request
                HttpResponseMessage responseMessage = await client.PostAsync(CHECKOUT, content).ConfigureAwait(true);
                //get message
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseJson);
                var message = jObject.GetValue("message").ToString();
                var state = false;
                if ((int)responseMessage.StatusCode == 200)
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

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    TableDetailItem detail = jObject.ToObject<TableDetailItem>();
                    return detail;
                } else if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    return null;
                }

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
                var fileName = jObject.GetValue("bill").ToString();
                var host = jObject.GetValue("host").ToString();

                DownloadFileToLocal(host, fileName, PrintType.Bill);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public async Task<Tuple<Boolean, String>> GetReceiptAsync(int id)
        {

            try
            {
                //send request
                HttpResponseMessage response = await client.GetAsync(GET_RECEIPT(id));
                //get access token from response body
                var responseJson = await response.Content.ReadAsStringAsync();
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jObject = JObject.Parse(responseJson);
                    var fileName = jObject.GetValue("paid").ToString();
                    var host = jObject.GetValue("host").ToString();
                    DownloadFileToLocal(host, fileName, PrintType.Receipt);
                    return Tuple.Create(true, "success");
                } else
                {
                    return Tuple.Create(false, "Just export bill before export receipt.");
                }
               
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message);
            }
            
        }

        public void DownloadFileToLocal(string host, string fileName, PrintType fileType)
        {
            using (WebClient webClient = new WebClient())
            {
                DateTime localDate = DateTime.Now;
                String urlString = "http://" + host + fileName;

                switch (fileType)
                {
                    case PrintType.Bill:
                        webClient.DownloadFile(urlString, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Bills\\" + localDate.ToString("de-DE") + fileName);
                        break;
                    case PrintType.Receipt:
                        webClient.DownloadFile(urlString, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Receipts\\" + localDate.ToString("de-DE") + fileName);

                        break;
                    case PrintType.Order:
                        webClient.DownloadFile(urlString, @"C:\\Users\\PC\\Desktop\\TDTU_DA2\\DesktopApp\\Downloads\\Orders\\" + localDate.ToString("de-DE") + fileName);

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
