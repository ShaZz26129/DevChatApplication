using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    public class CpmServiceHelper : ICpmServiceHelper
    {
        public async Task<CpmMyGuideResponse> GetCpmMyGuide(string tenantId, string tenantOuId, string AppId, string ViewType, string eventName)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL +
                    $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{ViewType}/{eventName}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.SendAsync(CpmRequestMessage);
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CpmMyGuideResponse>(responseBodyResource);
                if (CpmResponseResource.IsSuccessStatusCode)
                {
                    foreach (var item in data.Result)
                    {
                        Console.WriteLine(item.Name);
                    }
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        public async Task<JobByIdResponse> GetMyGuideJob(string tenantId, string tenantOuId, string AppId, string jobId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.GetAsync($"{Url.apiResourceServerURL}/api/Guide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobByIdResponse>(responseBodyResource);
                if (CpmResponseResource.IsSuccessStatusCode)
                {

                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        public async Task<JobUnderstoodResponse> GetJobUnderstood(string tenantId, string tenantOuId, string AppId, string jobId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.GetAsync($"{Url.apiResourceServerURL}/api/JobUnderstood/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUnderstoodResponse>(responseBodyResource);
                if (CpmResponseResource.IsSuccessStatusCode)
                {

                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        public async Task<GuideTreeResponse> GetGuideTreeData(string tenantId, string tenantOuId, string AppId, string CategoryId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.GetAsync($"{Url.apiResourceServerURL}/api/GuideTreeData/{tenantId}/{tenantOuId}/{AppId}/{CategoryId}");
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GuideTreeResponse>(responseBodyResource);
                if (CpmResponseResource.IsSuccessStatusCode)
                {

                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        public async Task<GuideTreeResponse> GetFilteredGuideTreeData(string CategoryId, string Category, string Count)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.GetAsync($"{Url.apiResourceServerURL}/api/GuideTreeData/{CategoryId}/{Category}/{Count}");
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GuideTreeResponse>(responseBodyResource);
                if (CpmResponseResource.IsSuccessStatusCode)
                {

                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        public async Task<ScheduleInfoResult> GetSchedule(string userId, int calendertype, string otypes, int tenantdetails)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                HttpResponseMessage CpmResponseResource = await httpClient.GetAsync($"http://point.tiptopplatform.com/Api/CalendarItems/{userId}/{calendertype}/{otypes}/{tenantdetails}");
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();


                if (CpmResponseResource.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<ScheduleInfoResult>(responseBodyResource);
                    //if(data.Result!=null && data.Result.Count > 0)
                    //{
                    //    data.Result.ForEach(u => {

                    //        if (u == data.Result.LastOrDefault())
                    //        {
                    //            if (u.recurrenceData.Contains("FREQ"))
                    //            {
                    //                int freqIndex = u.recurrenceData.IndexOf("FREQ");

                    //                if (freqIndex != -1)
                    //                {
                    //                    string modifiedInput = ModifyRecurrenceRule(u.recurrenceData, freqIndex);
                    //                    u.recurrenceData = modifiedInput;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                u.recurrenceData = "";
                    //            }
                    //        }
                    //        else
                    //        {
                    //            u.recurrenceData = "";
                    //        }


                    //    });
                    //}
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
        static string ModifyRecurrenceRule(string input, int freqIndex)
        {
            // Remove \r\n characters from the input string
            input = input.Replace("\r\n", "");

            // Extracting RRULE part from the input string
            string rrule = input.Substring(freqIndex);

            // Changing the format as requested
            string modifiedRRULE = Regex.Replace(rrule, @"(?<=FREQ=\w+;)(BYDAY:\w+;)(UNTIL=\d{4}\d{2}\d{2}T000000Z)", "BYDAY=MO,TU,WE,TH,FR; COUNT=10; $2");

            // Replacing RRULE in the input string
            string modifiedInput = input.Substring(0, freqIndex) + modifiedRRULE;
            string freq = input.Substring(freqIndex);
            freq = "FREQ" + freq;
            return freq;
        }
        public async Task<PostScheduleResponse> PostSchedule(ScheduleInfo scheduleInfo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("ApplicationId", App.ApplicationId);
            httpClient.DefaultRequestHeaders.Add("TenantId", App.TenantId);
            httpClient.DefaultRequestHeaders.Add("TenantOuId", App.TenantOuId);
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", App.ClientIpAddress);
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", App.ApiAccessToken);
            //  httpClient.BaseAddress = new Uri(Url.apiResourceServerURL);
            var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // HttpRequestMessage CpmRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url.apiResourceServerURL + $"/api/MyGuide/{tenantId}/{tenantOuId}/{AppId}/{jobId}");
            try
            {
                string str = JsonConvert.SerializeObject(scheduleInfo);
                var content = new StringContent(str, Encoding.UTF8, "application/json");
                HttpResponseMessage CpmResponseResource = await httpClient.PostAsync($"http://point.tiptopplatform.com/Api/CalendarItems", content);
                string responseBodyResource = await CpmResponseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<PostScheduleResponse>(responseBodyResource);

                if (CpmResponseResource.IsSuccessStatusCode)
                {

                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
        }
    }
}
