using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    class MessageServiceHelper
    {
        public async Task<ApplyLeaveMessMailResponseModel> PostApplyLeaveMessmail(List<ApplyLeaveMessMailRequestModel> applyLeaveMessMail)
        {
            //await ValidateTokenExpiry();
            AuthTokenResponse authToken = new AuthTokenResponse
            {
                access_token = App.accessToken,
                expires_in = App.accessTokenExpiresOn,
                refresh_token = App.refreshToken,
            };
            using (HttpClient httpClientResource = new HttpClient())
            {
                httpClientResource.BaseAddress = new Uri(Url.resourceServerURL);
                var json = JsonConvert.SerializeObject(applyLeaveMessMail);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                httpClientResource.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "Api/MailService");
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.Headers.Add("TenantId", App.TenantId);
                requestMessage.Headers.Add("TenantOUId", App.TenantOuId);
                requestMessage.Headers.Add("ApplicationId", App.ApplicationId);
                requestMessage.Headers.Add("ClientIpAddress", "::1");
                requestMessage.Headers.Add("ApiAccessToken", App.ApiAccessToken);
                requestMessage.Headers.Add("UserId", App.UserId);
                requestMessage.Content = content;
                try
                {
                    HttpResponseMessage responseResource = httpClientResource.SendAsync(requestMessage).Result;
                    string responsebodyResource = responseResource.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ApplyLeaveMessMailResponseModel>(responsebodyResource);
                    return result;
                }
                catch (Exception ex)
                {
                    var aa = ex;
                    return null;
                }
            }
        }
        public async Task<MessmailContentModel> GetMessMailContent(string FolderName, int TenantId, int MessBoxId, int appicationID, int PageId, bool apiStatus, bool Admin, string sType, int otype, int oid, int thrdid, int parentid, bool status, int startrow, int endrow, int pendrow, int pgsize, int objtype)
        {
            //await ValidateTokenExpiry();
            AuthTokenResponse authToken = new AuthTokenResponse
            {
                access_token = App.accessToken,
                expires_in = App.accessTokenExpiresOn,
                refresh_token = App.refreshToken,
            };
            using (HttpClient httpClientResource = new HttpClient())
            {
                httpClientResource.BaseAddress = new Uri(Url.resourceServerURL);
                httpClientResource.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/MessmailContent/" + FolderName + "/" + TenantId + "/" + MessBoxId + "/" + appicationID + "/" + PageId + "/" + apiStatus + "/" + Admin + "/" + sType + "/" + otype + "/" + oid + "/" + thrdid + "/" + parentid + "/" + status + "/" + startrow + "/" + endrow + "/" + pendrow + "/" + pgsize + "/" + objtype);
                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, ResourceServerUrlHelper.GetUrl(UrlKeys.EmployeeReportShift));
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.Headers.Add("TenantId", App.TenantId);
                requestMessage.Headers.Add("TenantOUId", App.TenantOuId);
                requestMessage.Headers.Add("ApplicationId", App.ApplicationId);
                requestMessage.Headers.Add("ClientIpAddress", "::1");
                requestMessage.Headers.Add("ApiAccessToken", App.ApiAccessToken);
                //Application.Current.MainPage.DisplayAlert("", Convert.ToString(requestMessage.RequestUri), "Ok");
                try
                {
                    HttpResponseMessage responseResource = httpClientResource.SendAsync(requestMessage).Result;
                    string responsebodyResource = responseResource.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<MessmailContentModel>(responsebodyResource);
                    return result;
                }
                catch (Exception ex)
                {
                    var aa = ex.Message;
                    return null;
                }
            }
        }
        public async Task<ChildMessageMailResponseModel> GetOldChildMessMail(string TenantId, string MessBoxId, string appicationID, string PageId, bool Status, string sType, string parentId, string otype, string objtype, string VersionDateTime, int StartRowId, int EndRowId)
        {
            AuthTokenResponse authToken = new AuthTokenResponse
            {
                access_token = App.accessToken,
                expires_in = App.accessTokenExpiresOn,
                refresh_token = App.refreshToken,
            };
            using (HttpClient httpClientResource = new HttpClient())
            {
                httpClientResource.BaseAddress = new Uri(Url.resourceServerURL);
                httpClientResource.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/MessmailChildContent/" + TenantId + "/" + MessBoxId + "/" + appicationID + "/" + PageId + "/" + Status + "/" + sType + "/" + parentId + "/" + otype + "/" + objtype + "/" + VersionDateTime + "/" + StartRowId + "/" + EndRowId);
                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, ResourceServerUrlHelper.GetUrl(UrlKeys.EmployeeReportShift));
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.Headers.Add("TenantId", App.TenantId);
                requestMessage.Headers.Add("TenantOUId", App.TenantOuId);
                requestMessage.Headers.Add("ApplicationId", App.ApplicationId);
                requestMessage.Headers.Add("ClientIpAddress", "::1");
                requestMessage.Headers.Add("ApiAccessToken", App.ApiAccessToken);
                try
                {
                    //Application.Current.MainPage.DisplayAlert("", Convert.ToString(requestMessage.RequestUri), "ok");
                    HttpResponseMessage responseResource = httpClientResource.SendAsync(requestMessage).Result;
                    string responsebodyResource = responseResource.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ChildMessageMailResponseModel>(responsebodyResource);
                    return result;
                }
                catch (Exception ex)
                {
                    var aa = ex.Message;
                    return null;
                }
            }
        }
        public async Task<ParticipantsModel> GetParticipants(string tenantId, string messboxid, string applicationid, string pageid, string serachtentid, string username)
        {
            var BarrelData = Barrel.Current.Get<ParticipantsModel>(key: App.GetParticipantData);
            if (BarrelData != null && BarrelData.Result != null && BarrelData.Result.Count > 0 && !Barrel.Current.IsExpired(key: App.GetParticipantData))
            {
                return BarrelData;
            }
            else
            {
                //await ValidateTokenExpiry();
                AuthTokenResponse authToken = new AuthTokenResponse
                {
                    access_token = App.accessToken,
                    expires_in = App.accessTokenExpiresOn,
                    refresh_token = App.refreshToken,
                };
                using (HttpClient httpClientResource = new HttpClient())
                {
                    httpClientResource.BaseAddress = new Uri(Url.resourceServerURL);
                    httpClientResource.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
                    //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/localparticipants/Root/" + tenantId + "/" + messboxid + "/" + applicationid + "/" + pageid + "/" + serachtentid + "/" + username);
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/Participants/" + tenantId);
                    //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, ResourceServerUrlHelper.GetUrl(UrlKeys.EmployeeReportShift));
                    requestMessage.Headers.Add("Accept", "application/json");
                    requestMessage.Headers.Add("TenantId", App.TenantId);
                    requestMessage.Headers.Add("TenantOUId", App.TenantOuId);
                    requestMessage.Headers.Add("ApplicationId", App.ApplicationId);
                    requestMessage.Headers.Add("ClientIpAddress", "::1");
                    requestMessage.Headers.Add("ApiAccessToken", App.ApiAccessToken);
                    try
                    {
                        HttpResponseMessage responseResource = httpClientResource.SendAsync(requestMessage).Result;
                        string responsebodyResource = responseResource.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<ParticipantsModel>(responsebodyResource);
                        if (result.Result != null)
                        {
                            Barrel.Current.Empty(key: App.GetParticipantData);
                            Barrel.Current.Add(key: App.GetParticipantData, data: result, expireIn: TimeSpan.FromDays(1));
                        }
                        return result;
                    }
                    catch (Exception ex)
                    {
                        var aa = ex;
                        return null;
                    }
                }
            }
        }

    }
}
