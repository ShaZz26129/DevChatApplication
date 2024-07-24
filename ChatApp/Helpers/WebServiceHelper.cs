//using Java.Net;
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
    internal class WebServiceHelper : IWebServiceHelper
    {
        public bool flag = false;
        public async Task<bool> Login(string tenantName, string userName, string password)
        {
            if (!flag)
            {
                Console.WriteLine(flag);
                try
                {
                    var authToken = await GetToken(tenantName, userName, password);
                    if (authToken != null)
                    {
                        if (authToken.access_token != null)
                        {

                            App.GetApiResponce = true;
                            App.accessToken = authToken.access_token;
                            App.accessTokenExpiresOn = authToken.expires_in;
                            App.accessTokenReceivedOn = DateTime.UtcNow;
                            App.refreshToken = authToken.refresh_token;
                            //AuthToken = authToken;
                            var getIdentityData = await GetUserIdentity(authToken);
                            if (getIdentityData != null)
                            {
                                Console.WriteLine("Identity Chal Parhi haii");
                            }
                            var getsession = await UserSession(authToken);
                            if (getsession != null)
                            {
                                App.GetApiResponce = true;
                                flag = false;
                                return flag;
                            }

                            return flag;
                        }
                        else
                        {
                            App.GetApiResponce = true;
                            flag = false;
                            return flag;
                        }
                    }
                    else
                    {
                        App.GetApiResponce = false;
                        flag = false;
                        return flag;
                    }
                    //}
                }
                catch (Exception ex)
                {
                    var aa = ex;
                    App.GetApiResponce = false;
                    flag = false;
                    return flag;
                }
            }
            return flag;
        }

        public async Task<AuthTokenResponse> GetToken(string companyID, string userName, string password)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(Url.oAuthTokenURL);
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("CompanyID", companyID));
                postData.Add(new KeyValuePair<string, string>("UserName", userName));
                postData.Add(new KeyValuePair<string, string>("Password", password));
                postData.Add(new KeyValuePair<string, string>("client_id", App.ClientId));
                postData.Add(new KeyValuePair<string, string>("client_secret", App.ClientSecret));
                //postData.Add(new KeyValuePair<string, string>("returnUrl", model.ReturnURL));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                var json = JsonConvert.SerializeObject(postData);
                HttpContent content = new FormUrlEncodedContent(postData);
                //shahzaib ny delay ko comment kiya haii 
                //await Task.Delay(100);
                //content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                //var req = new HttpRequestMessage(HttpMethod.Post, "OAuth/Token") { Content =content };
                try
                {

                    //HttpResponseMessage response = httpClient.PostAsync("OAuth/Token", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                    //var response = httpClient.SendAsync(req).Result;

                    HttpResponseMessage response = await httpClient.PostAsync(Url.oAuthTokenURL + "/OAuth/Token", content);
                    string responsebody = await response.Content.ReadAsStringAsync();
                    var authToken = JsonConvert.DeserializeObject<AuthTokenResponse>(responsebody);
                    App.accessToken = authToken.access_token;
                    Barrel.Current.Add<string>($"token", authToken.access_token, TimeSpan.FromMinutes(20));
                    return authToken;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    Console.WriteLine("Error occured due to" + ex.Message);
                    return null;
                }
            }
        }
        public async Task<UserIdentity> GetUserIdentity(AuthTokenResponse authToken)
        {
            var data = JsonConvert.SerializeObject(authToken);
            using (HttpClient httpClient = new HttpClient())
            {
                //new WebservicesHelper().ValidateTokenExpiry();
                AuthTokenResponse authTokenResponse = new AuthTokenResponse
                {
                    access_token = authToken.access_token,
                    expires_in = authToken.expires_in,
                    refresh_token = authToken.refresh_token,
                };
                //var newClass = new
                //{
                //    AccessToken = obj.access_token,
                //    RefreshToken = authTokenResponse.refresh_token,
                //    AccessTokenIssueDate = DateTime.Now,
                //    AccessTokenExpiration = authTokenResponse.expires_in

                //};

                //httpClient.BaseAddress = new Uri(Url.resourceServerURL);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authTokenResponse.access_token);
                // Add a new Request Message 
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Url.resourceServerURL + "/api/UserIdentity");
                // Add our custom headers       
                requestMessage.Headers.Add("ApplicationId", App.ApplicationId);
                requestMessage.Headers.Add("ClientIpAddress", App.ClientIpAddress);
                requestMessage.Headers.Add("ApiAccessToken", App.ApiAccessToken);
                //requestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage responseResource = await httpClient.SendAsync(requestMessage);
                    string responsebodyResource = await responseResource.Content.ReadAsStringAsync();
                    var userIdentity = JsonConvert.DeserializeObject<UserIdentity>(responsebodyResource);
                    if (userIdentity != null && userIdentity.Result != null)
                    {
                        //Barrel.Current.Empty(key: App.GetloginUserIdentity);
                        App.Username = userIdentity.Result.FullName.Split()[0];
                        App.UserId = userIdentity.Result.UserId;
                        App.EmpName = userIdentity.Result.FullName;
                        App.EmpId = userIdentity.Result.UserExId;
                        App.UserProfilePic = userIdentity.Result.UserImageUrl;
                        App.EmailId = userIdentity.Result.EmailID;
                        foreach (var chldList in userIdentity.Result.TenantClaims.Select(u => u.Children).ToList())
                        {
                            foreach (var item2 in chldList)
                            {
                                if (item2.Value.OuType == 3)
                                {
                                    App.MessageBoxId = item2.Value.MessBoxId.ToString();
                                    userIdentity.MessageBoxId = item2.Value.MessBoxId.ToString();
                                    var GetdesigId = item2.Value.DefaultDesignationOuID.ToString();
                                    var DesigshortName = item2.Value.DefaultDesignationShortName;
                                    if (GetdesigId != "")
                                        App.DesignationID = item2.Value.DefaultDesignationOuID.ToString();
                                    if (DesigshortName != null && DesigshortName != "")
                                        App.DefaultDesignationShortName = item2.Value.DefaultDesignationShortName;
                                }
                            }

                        }
                        await SecureStorage.SetAsync("SetUsername", App.Username);
                        await SecureStorage.SetAsync("SetEmpName", App.EmpName);
                        await SecureStorage.SetAsync("SetEmpId", Convert.ToString(App.EmpId));
                        await SecureStorage.SetAsync("DesignationID", App.DesignationID);
                        await SecureStorage.SetAsync("SetEmailId", App.EmailId);
                        if (App.UserProfilePic != null)
                            await SecureStorage.SetAsync("SetUserProfilePic", App.UserProfilePic);
                        else
                            await SecureStorage.SetAsync("SetUserProfilePic", string.Empty);
                        await SecureStorage.SetAsync("SetMessageboxid", App.MessageBoxId);
                        await SecureStorage.SetAsync("DesignationShortName", App.DefaultDesignationShortName);
                        // Barrel.Current.Add(key: App.GetloginUserIdentity, data: userIdentity, expireIn: TimeSpan.FromDays(1));
                        return userIdentity;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    Console.WriteLine("Error occured due to" + ex.Message + "GetUserIdentity");
                    return null;
                }
            }
        }
        public async Task<AuthTokenResponse> UserSession(AuthTokenResponse authTokenResponse)
        {
            //string url = "https://api3.tiptopplatform.com/api/usersession";
            //string accessToken = App.accessToken.ToString(); // Replace with your access token
            HttpClient httpClient = new HttpClient();
            var newClass = new
            {

                AccessToken = authTokenResponse.access_token,
                RefreshToken = authTokenResponse.refresh_token,
                AccessTokenIssueDate = DateTime.UtcNow,
                AccessTokenExpiration = DateTime.UtcNow.AddHours(10)

            };
            //App.accessToken = newClass.AccessToken;
            var json = JsonConvert.SerializeObject(newClass);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("ApplicationId", "31");
            httpClient.DefaultRequestHeaders.Add("TenantId", "5");
            httpClient.DefaultRequestHeaders.Add("TenantOuId", "1");
            httpClient.DefaultRequestHeaders.Add("ClientIpAddress", "::1");
            httpClient.DefaultRequestHeaders.Add("ApiAccessToken", "de4402ed5cf40764b6bf26100a0ceaca02a95066");
            //var token = Barrel.Current.Get<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authTokenResponse.access_token);

            //  HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, Url.userSessionURL + "/api/usersession");
            try
            {
                var responseResource = await httpClient.PostAsync("http://api3.tiptopplatform.com/api/usersession", content);
                string responsebodyResource = await responseResource.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<AuthTokenResponse>(responsebodyResource);
                if (responseResource.IsSuccessStatusCode)
                {
                    Console.WriteLine("Session Created");
                    return data;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                Console.WriteLine("Error occured due to" + ex.Message);
                return null;
            }
            //var response = await requestMessage.Content.ReadAsStringAsync();
            return null;
        }
    }
}
